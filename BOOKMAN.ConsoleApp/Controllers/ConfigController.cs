﻿using System;

namespace BOOKMAN.ConsoleApp.Controllers
{
    using Framework;
    internal class ConfigController : ControllerBase
    {
        private Config _c = Config.Instance;
        public void ConfigPromptText(string text)
        {
            _c.PromptText = text;
            Success("The command prompt will change next time");
        }
        public void ConfigPromptColor(string text)
        {
            if(Enum.TryParse(text, true, out ConsoleColor color))
            {
                _c.PromptColor = color;
                Success("The command prompt color will change next time");
            }
        }
        public void CurrentDataAccess()
        {
            var da = _c.DataAccess;
            var file = _c.DataFile;
            Inform($"Current data access engine: {da}\r\nCurrent data file: {file}");
        }
        public void ConfigDataAccess(string da, string file)
        {
            _c.DataAccess = da;
            _c.DataFile = file;
            Success("The change will be available next time");
        }
    }
}
