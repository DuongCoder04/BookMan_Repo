using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOOKMAN.ConsoleApp
{
    using DataServices;
    internal class Config
    {
        private static Config _instance;
        public static Config Instance = _instance ?? (_instance = new Config());
        private Config() { }
        private Properties.Settings _s = Properties.Settings.Default;
        public void Reload() => _s.Reload();
        public IDataAccess IDataAccess
        {
            get
            {
                var da = _s.DataAccess;
                switch (da.ToLower())
                {
                    case "binary": return new BinaryDataAccess();
                    case "json": return new JsonDataAccess();
                    case "xml": return new XmlDataAccess();
                    default: return new BinaryDataAccess();
                }
            }
        }
        public string DataAccess
        {
            get => _s.DataAccess;
            set
            {
                _s.DataAccess = value;
                _s.Save();
            }
        }
        public string PromptText
        {
            get => _s.PromptText;
            set
            {
                _s.PromptText = value;
                _s.Save();
            }
        }
        public ConsoleColor PromptColor
        {
            get => _s.PromptColor;
            set
            {
                _s.PromptColor = value;
                _s.Save();
            }
        }
        public string DataFile
        {
            get => _s.DataFile;
            set
            {
                _s.DataFile = value;
                _s.Save();
            }
        }
    }
}
