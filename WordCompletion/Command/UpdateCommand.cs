using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCompletion.Command
{
    class UpdateCommand : Command
    {
        public UpdateCommand(Builder.VocabularyBuilder vocabularyBuilder,string path)
        {
            _vocabularyBuilder = vocabularyBuilder;
            fileHandler = new Handlers.FileHandler(path);
        }
        public override void Execute()
        {
            var words = fileHandler.Words;
            _vocabularyBuilder.WriteInVocabulary(words);
        }
    }
}
