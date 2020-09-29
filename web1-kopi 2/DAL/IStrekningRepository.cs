using System.Collections.Generic;
using System.Threading.Tasks;
using Gruppeoppgave1.model;

namespace Gruppeoppgave1.DAL
{
    public interface IStrekningRepository
    {


        Task<bool> lagreStrekning(Strekning lagreStrekning);
        Task<bool> endreStrekning(int SId, Strekning endreStrekning);
        Task<bool> slettStrekning(int SId);
        Task <List<Strekning>> HentalleStrekning();
        Task<Strekning> hentEnStrekning(int SId);


    }
}
// check git


