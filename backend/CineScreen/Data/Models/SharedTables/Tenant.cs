using CineScreen.Helper.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineScreen.Data.Models.SharedTables
{

    public class Tenant : SharedTableBase
    {
        public string Name { get; set; } = string.Empty; 
        public string DatabaseConnection { get; set; } = string.Empty; 
        public string ServerAddress { get; set; } = string.Empty; 
    }

}
