using System;
using System.IO;

namespace WordCompletion.Handlers
{
    public class FileHandler
    {
        public string[] Words { get; }
        public FileHandler(string path)
        {
            var text = File.ReadAllText(path).Replace("\r","");

            Char[] charToSplit = { ',', '.', ' ', '\n' };

            Words = text.Split(charToSplit);
        }
    }
}
