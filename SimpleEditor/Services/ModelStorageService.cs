namespace SimpleEditor.Services
{
    public class ModelStorageService : IStorageService
    {
        private string _savedText = string.Empty;

        private readonly string _lockObj = string.Empty;

        public void Save(string text)
        {
            lock (_lockObj)
            {
                _savedText = text;
            }
        }

        public string Load()
        {
            lock (_lockObj)
            {
                return _savedText ?? string.Empty;
            }
        }
    }
}