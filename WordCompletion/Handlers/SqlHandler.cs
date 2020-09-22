using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordCompletion.Vocabulary;

namespace WordCompletion.Handlers
{
    public class SqlHandler
    {
        SqlConnection sqlConnection;
        public SqlHandler()
        {
            var currentDirectory = Environment.CurrentDirectory;
            var path = currentDirectory.Remove(currentDirectory.Length - 9);

            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + path + "Database.mdf;Integrated Security = True";

            sqlConnection = new SqlConnection(connectionString);

            if (sqlConnection.State == System.Data.ConnectionState.Closed)
            {
                sqlConnection.Open();
            }
        }

        public Word[] Select(string queryString)
        {
            SqlDataReader sqlReader = null;

            SqlCommand sqlCommand = new SqlCommand(queryString, sqlConnection);

            List<Word> words = new List<Word>();
            try
            {
                sqlReader = sqlCommand.ExecuteReader();
                while (sqlReader.Read())
                {
                    var word = Convert.ToString(sqlReader["Word"]);
                    var repetitions = Convert.ToInt32(sqlReader["Importance"]);
                    words.Add(new Word(word, repetitions));
                }

                return words.ToArray();
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                if (sqlReader != null)
                {
                    sqlReader.Close();
                }
            }
            return null;
        }

        /// <summary>
        /// Атрибутами являются Word и Importance
        /// </summary>
        /// <param name="queryString"></param>
        public void InsertOrUpdate(string queryString, string word, int repetitions)
        {
            SqlCommand sqlCommand = new SqlCommand(queryString, sqlConnection);

            sqlCommand.Parameters.AddWithValue("Word", word);

            sqlCommand.Parameters.AddWithValue("Importance", repetitions.ToString());

            sqlCommand.ExecuteNonQuery();
        }

        public void Clear()
        {
            SqlCommand sqlCommand = new SqlCommand("TRUNCATE TABLE Vocabulary", sqlConnection);

            sqlCommand.ExecuteNonQuery();
        }
    }
}
