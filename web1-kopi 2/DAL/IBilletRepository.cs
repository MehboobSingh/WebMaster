using System.Collections.Generic;
using System.Threading.Tasks;
using Gruppeoppgave1.model;

namespace Gruppeoppgave1.DAL
{
    public interface IBilletRepository
    {
       Task<bool> lagreBillet(Billet lagreBillet);

        Task<bool> endreBillet(int BId, Billet endreBillet);
        Task<bool> slettBillet(int BId);
        Task<List<Billet>> HentalleBilleter();
       Task< Billet> hentEnBillet(int BId);
    }
}