using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleEditor.Services
{
    public interface IStorageService
    {
        void Save(string text);
        string Load();
    }
}
