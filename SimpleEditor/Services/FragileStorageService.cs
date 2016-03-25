namespace SimpleEditor.Services
{
    #region Usings
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    #endregion

    public class FragileStorageService : IStorageService
    {
        #region Fields
        private readonly string _path;

        private readonly Queue<string> _commandsLog = new Queue<string>();
        #endregion

        public FragileStorageService()
        {
            var currentDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            _path = Path.Combine(currentDir, "saved_text.txt");
            File.Delete(_path);
        }

        public void Save(string text)
        {
            #region Fragile code
            if (!string.IsNullOrWhiteSpace(text) && text.Length >= 5)
            {
                _commandsLog.Enqueue("Save");
            }
            #endregion

            File.WriteAllText(_path, text);
        }

        public string Load()
        {
            #region Fragile code
            _commandsLog.Enqueue("Load");

            if (BadState())
            {
                return Error();
            }
            #endregion

            return File.Exists(_path) ? File.ReadAllText(_path) : string.Empty;
        }

        #region Fragile code

        private bool BadState()
        {
            var failPattern = new[] { "Save", "Save", "Save", "Load" };

            return _commandsLog
                .ToArray()
                .Reverse()
                .Take(4)
                .Reverse()
                .SequenceEqual(failPattern);
        }

        private string Error()
        {
            return "error";
        }

        #endregion
    }
}