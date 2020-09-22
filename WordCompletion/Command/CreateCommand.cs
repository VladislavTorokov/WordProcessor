using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCompletion.Command
{
    class CreateCommand : Command
    {
        public CreateCommand(Builder.VocabularyBuilder vocabularyBuilder,string path)
        {
            _vocabularyBuilder = vocabularyBuilder;
            fileHandler = new Handlers.FileHandler(path);
        }
        public override void Execute()
        {
            _vocabularyBuilder.ClearVocabulary();
            var words = fileHandler.Words;
            _vocabularyBuilder.WriteInVocabulary(words);
        }
    }
}
