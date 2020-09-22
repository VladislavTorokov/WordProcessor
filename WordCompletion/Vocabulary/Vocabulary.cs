using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCompletion.Vocabulary
{
    class Vocabulary
    {
        public List<Word> Words { get; set; }

        public Vocabulary()
        {
            Words = new List<Word>();
        }
    }
}
