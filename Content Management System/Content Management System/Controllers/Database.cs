using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Content_Management_System.Controllers
{
    public class Database : IDisposable
    {
        public System.Data.Common.DbConnection connection { get; }
    }
}