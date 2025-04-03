using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;

namespace Cozify
{
    public static class GlobalUser//database helper
    {
        public static string LoggedInUsername { get; set; }
    }
}
