using DemocracyMobile.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net.Interop;

namespace DemocracyMobile.WinPhone
{
    public class Config : IConfig
    {
        private string directoryDB;
        private ISQLitePlatform platform;

        public string DirectoryDB
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public ISQLitePlatform Platform
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}
