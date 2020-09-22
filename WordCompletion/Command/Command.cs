using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordCompletion.Handlers;

namespace WordCompletion.Command
{
    public abstract class Command
    {
        public abstract void Execute();
        public Builder.VocabularyBuilder _vocabularyBuilder { get; set; }
        protected FileHandler fileHandler;
        public static Command Create(Builder.VocabularyBuilder vocabularyBuilder, string parameter, string path)
        {
            switch (parameter)
            {
                case "Create": return new CreateCommand(vocabularyBuilder, path);
                case "Update": return new UpdateCommand(vocabularyBuilder, path);
                case "Clear": return new ClearCommand(vocabularyBuilder);
                case "": return new ExitCommand();
                default: return new InputModeCommand(vocabularyBuilder, parameter);
            }
        }
    }
}
