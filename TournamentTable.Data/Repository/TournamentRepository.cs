using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentTable.Data.Base;
using TournamentTable.Domain;
using Dapper;

namespace TournamentTable.Data.Repository
{
    public class TournamentRepository : BaseRepository, ITournamentRepository
    {
        public TournamentRepository() : base("Tournament") { }

        public IEnumerable<Tournament> Get()
        {
            IEnumerable<Tournament> items = null;

            using (var connection = Connection) 
            {
                connection.Open();
                items = connection.Query<Tournament>("SELECT * FROM " + _tblName);
            }

            return items;
        }

        public Task<IEnumerable<Tournament>> GetAsync()
        {
            throw new NotImplementedException();
        }
    }
}
