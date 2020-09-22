using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCompletion.Vocabulary
{
    public class Word
    {
        public string value { get; }
        public int Repetitions { get; set; }

        public Word(string word)
        {
            value = word;
            Repetitions = 1;
        }

        public Word(string word,int repetitions)
        {
            value = word;
            Repetitions = repetitions;
        }

        public void IncrementRepetitions()
        {
            Repetitions++;
        }
    }
}
