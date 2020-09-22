using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCompletion.Command
{
    class ExitCommand : Command
    {
        public override void Execute()
        {
            Environment.Exit(0);
        }
    }
}
