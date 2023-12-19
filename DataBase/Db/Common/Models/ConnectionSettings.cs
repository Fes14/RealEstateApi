using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Db.Common.Models
{
    public class ConnectionSettings
    {
        public string ConnectionString { get; set; }
        public int CommandTimeout { get; set; }
        public bool InMemory { get; set; }
    }
}
