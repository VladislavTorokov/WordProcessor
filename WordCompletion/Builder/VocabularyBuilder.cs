using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordCompletion.Handlers;

namespace WordCompletion.Builder
{
    public class VocabularyBuilder
    {
        private Vocabulary.Vocabulary vocabulary;
        private SqlHandler sqlHandler;


        public VocabularyBuilder()
        {
            vocabulary = new Vocabulary.Vocabulary();
            sqlHandler = new SqlHandler();

            var query = "SELECT Word,Importance FROM [Vocabulary]";
            var words = sqlHandler.Select(query);
            vocabulary.Words.AddRange(words);
        }

        private void AddWord(string word)
        {
            if (word.Length > 2 && word.Length < 15)
            {
                if (!CheckWordAlreadyAdded(word))
                {
                    vocabulary.Words.Add(new Vocabulary.Word(word));
                }
            }
        }

        private bool CheckWordAlreadyAdded(string word)
        {
            var index = vocabulary.Words.FindIndex(dictionaryWord => dictionaryWord.value.Contains(word));
            if (index >= 0)
            {
                vocabulary.Words[index].IncrementRepetitions();
                if (vocabulary.Words[index].Repetitions > 2)
                {
                    if(vocabulary.Words[index].Repetitions==3)
                    {
                        string query = "INSERT INTO [Vocabulary] (Word,Importance)VALUES(@Word, @Importance)";
                        sqlHandler.InsertOrUpdate(query, word, 3);
                    }
                    else 
                    {
                        var repetitions = vocabulary.Words[index].Repetitions;
                        var query = "UPDATE [Vocabulary] SET [Importance]=@Importance WHERE [Word]=@Word";
                        sqlHandler.InsertOrUpdate(query, word, repetitions);
                    }
                }
                return true;
            }
            return false;
        }

        public void WriteInVocabulary(string[] words)
        {
            foreach (var word in words)
            {
                AddWord(word);
            }
        }

        public Vocabulary.Word[] SelectSilmilarWords(string word)
        {
            var query = $"SELECT Word,Importance FROM [Vocabulary] WHERE [Word] LIKE N'{word}%'";
            var words = sqlHandler.Select(query);

            return words;
        }

        public void ClearVocabulary()
        {
            vocabulary.Words.Clear();
            sqlHandler.Clear();
        }
    }
}
