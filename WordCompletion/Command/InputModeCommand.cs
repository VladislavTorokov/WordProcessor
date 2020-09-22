using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCompletion.Command
{
    class InputModeCommand : Command
    {
        string word;
        public InputModeCommand(Builder.VocabularyBuilder vocabularyBuilder,string parameter)
        {
            _vocabularyBuilder = vocabularyBuilder;
            word = parameter;
        }
        public override void Execute()
        {
            var words = _vocabularyBuilder.SelectSilmilarWords(word);

            //Сортировка и выбор первых 5ти элементов
            var newWords = words.OrderByDescending(word => word.Repetitions).ThenBy(word => word.value).Take(5);
            foreach (var word in newWords)
            {
                Console.WriteLine(word.value);
            }
        }
    }
}
