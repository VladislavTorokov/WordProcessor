using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCompletion
{
    class Program
    {
        static void Main(string[] args)
        {
            Builder.VocabularyBuilder vocabularyBuilder = new Builder.VocabularyBuilder();

            Menu();

            while (true)
            {
                var userStrings = GetUserStrings();

                var command = Command.Command.Create(vocabularyBuilder, userStrings[0], userStrings[1]);
                if (command != null)
                    command.Execute();
                if (command != null)
                    vocabularyBuilder = command._vocabularyBuilder;
                else
                    Console.WriteLine("Некорректный ввод");
            }
        }

        static void Menu()
        {
            Console.WriteLine("Доступны следующие команды:");
            Console.WriteLine("Create - создание словаря");
            Console.WriteLine("Update - обновление словаря");
            Console.WriteLine("Clear - очистить словарь");
            Console.WriteLine("Или введите пустую строку для выхода");
        }

        static string[] GetUserStrings()
        {
            List<string> userStrings = new List<string>(2);
            string path = null;

            string userString = Console.ReadLine();

            var userStringWithoutSpaces = userString.Replace(" ", "");

            if (userStringWithoutSpaces == "Create" || userStringWithoutSpaces == "Update")
            {
                Console.WriteLine("Введите путь к файлу");
                path = Console.ReadLine();
            }
            userStrings.Add(userStringWithoutSpaces);
            userStrings.Add(path);

            return userStrings.ToArray();
        }
    }
}
