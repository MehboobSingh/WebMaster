  using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gruppeoppgave1.model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Gruppeoppgave1.DAL
{

    public class StrekningRepository : DAL.IStrekningRepository
    {

        private DBContext _sdb;

            private ILogger<StrekningRepository> _log;

         


        public StrekningRepository(DBContext db, ILogger<StrekningRepository> log)
    {
        _sdb = db;
        _log = log;
          

        }



    public async Task<bool> lagreStrekning(Strekning lagreStrekning)
        {

             try
                {
                    var nyStrekningRad = new Strekninger();

                    nyStrekningRad.Fra = lagreStrekning.Fra;
                    nyStrekningRad.Til = lagreStrekning.Til;


                     await _sdb.Strekninger.AddAsync(nyStrekningRad);
                    await _sdb.SaveChangesAsync();
                    return true;

                }
                catch (Exception e )
                {
                    _log.LogInformation(e.Message);
                    return false;
                }

            }
        


    


    public async Task <Strekning> hentEnStrekning(int SId)
        {
          

                var enDbStrekning = await _sdb.Strekninger.FindAsync(SId);

                if (enDbStrekning == null)
                {
                    return null;
                }
                else
                {
                    var utStrekning = new Strekning()
                    {
                        SId = enDbStrekning.SId,
                        Fra = enDbStrekning.Fra,
                        Til = enDbStrekning.Til


                    };
                    return utStrekning;
                }
            }
        



        public async Task<List<Strekning>> HentalleStrekning()

        {
             List<Strekning> alleStrekning = await _sdb.Strekninger.Select(k => new Strekning
                {
                    SId = k.SId,
                    Fra = k.Fra,
                    Til = k.Til

                }).ToListAsync();

                return alleStrekning;
            }
        






        public async Task <bool> slettStrekning(int SId)
        {
             try
                {
                    var slettObjekt = await _sdb.Strekninger.FindAsync(SId);
                    _sdb.Strekninger.Remove(slettObjekt);
                    await _sdb.SaveChangesAsync();
                    return true;
                }
                catch (Exception e )
                {
                    _log.LogInformation(e.Message);
                    return false;
                }
            }
        

        public async Task<bool> endreStrekning(int SId, Strekning endreStrekning)
        {
         try
                {
                    Strekninger endreStrekninger = await _sdb.Strekninger.FindAsync(SId);
                    endreStrekninger.Fra = endreStrekning.Fra;
                    endreStrekninger.Til = endreStrekning.Til;

                    await _sdb.SaveChangesAsync();
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

