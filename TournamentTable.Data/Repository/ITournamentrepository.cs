using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentTable.Domain;

namespace TournamentTable.Data.Repository
{
    public interface ITournamentRepository
    {
        IEnumerable<Tournament> Get();

        Task<IEnumerable<Tournament>> GetAsync();
    }
}
