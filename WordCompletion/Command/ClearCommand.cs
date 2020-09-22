using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCompletion.Command
{
    class ClearCommand : Command
    {
        public ClearCommand(Builder.VocabularyBuilder vocabularyBuilder)
        {
            _vocabularyBuilder = vocabularyBuilder;
        }
        public override void Execute()
        {
            _vocabularyBuilder.ClearVocabulary();
        }
    }
}
