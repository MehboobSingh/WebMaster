
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gruppeoppgave1.model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Gruppeoppgave1.DAL
{
    public class BilletRepository : DAL.IBilletRepository
    {
        private DBContext _db;
        private ILogger<BilletRepository> _log;
       


        public BilletRepository(DBContext db, ILogger<BilletRepository> log)
        {
            _db = db;
            _log = log;
            
        }


        public async Task<bool> lagreBillet(Billet lagreBillet)
        {

            using (var _db = new DBContext())
            {
                try
                {
                    var nyBilletRad = new Billeter();
                    nyBilletRad.FraogTiltur = lagreBillet.FraogTiltur;
                    nyBilletRad.Price = lagreBillet.Price;
                    nyBilletRad.StrekningId = lagreBillet.StrekningId;


                    await _db.Billeter.AddAsync(nyBilletRad);

                    await _db.SaveChangesAsync();
                    return true;

                }
                catch (Exception e)
                {
                    _log.LogInformation(e.Message);
                    return false;
                }

            }
        }



           



        public async Task<Billet> hentEnBillet(int BId)
        {
            try
            {

                Billeter enBillet = await _db.Billeter.FindAsync(BId);

                var utBillet = new Billet()
                {
                    BId = enBillet.BId,
                    FraogTiltur = enBillet.FraogTiltur,
                    Price = enBillet.Price,
                    StrekningId = enBillet.StrekningId,

                };
                return utBillet;
            }
            catch (Exception e)
            {
                _log.LogInformation(e.Message);
                return null;
            }
        }

        

        public async Task<List<Billet>> HentalleBilleter()

        {

            using (var _db = new DBContext())
            {
                var billet = new Billet();
                try
                {

                    List<Billet> alleBilleter = await _db.Billeter.Select(a => new Billet
                    {

                        BId = a.BId,
                        FraogTiltur = a.FraogTiltur,
                        Price = a.Price,
                        StrekningId = a.StrekningId,


                    }).ToListAsync();
                    return alleBilleter;
                }
                catch (Exception e)
                {
                    _log.LogInformation(e.Message);
                    return null;

                }
            }
        }



                public async Task<bool> slettBillet(int BId)

        {
            using (var _db = new DBContext())
            {
                try
                {
                    //hello test
                    var slettObjekt = _db.Billeter.Find(BId);
                    _db.Billeter.Remove(slettObjekt);
                    await _db.SaveChangesAsync();
                    return true;
                }
                catch (Exception e )
                {
                    _log.LogInformation(e.Message);
                     return false;
                }
            }
        }

        public async Task<bool> endreBillet(int BId, Billet endreBillet)
        {

            using (var _db = new DBContext())
            {
                try
                {
                    Billeter endreBilleter = _db.Billeter.Find(BId);
                    endreBilleter.FraogTiltur = endreBillet.FraogTiltur;
                    endreBilleter.Price = endreBillet.Price;
                    endreBilleter.StrekningId = endreBillet.StrekningId;


                    await _db.SaveChangesAsync();
                    return true;

                }
                catch (Exception e )
                {
                    _log.LogInformation(e.Message);
                    return false;
                }

            }
        }


    }
}