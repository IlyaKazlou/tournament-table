using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournamentTable.Data.Base
{
    public class BaseRepository : IRepository
    {
        protected readonly string _tblName;

        public BaseRepository(string tblName) 
        {
            _tblName = tblName;
        }

        protected SqlConnection Connection
        {
            get { return new SqlConnection(ConfigurationManager.ConnectionStrings["TournamentTableDb"].ConnectionString); }
        }
    }
}
