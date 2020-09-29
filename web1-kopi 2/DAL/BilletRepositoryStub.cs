using System.Collections.Generic;
using Gruppeoppgave1.model;

namespace Gruppeoppgave1.DAL
{
    public class BilletRepositoryStub 

    {
    public bool lagreBilletFraogTiltur(Billet lagreBillet)
        {

            if (lagreBillet.FraogTiltur == "")
            {
                return false;
            }
            else
            {
                return true;
            }

        }

     

        public bool endreBillet(int id, Billet endreBillet)
        {
            if (id == 0)
            {
                return false;
            }
            else
            {
                return true;
            }



        }
        public bool slettBillet(int id)
        {
            if (id == 0)
            {
                return false;
            }
            else
            {
                return true;
            }




        }
        public List<Billet> HentalleBilleter()
        {

            var billetListe = new List<Billet>();
            var billet = new Billet()
            {
                BId = 1,
                FraogTiltur = "10:30-12:30",
                Price = 299,
                StrekningId=1




            };
            billetListe.Add(billet);
            billetListe.Add(billet);
            billetListe.Add(billet);
            return billetListe;


        }
        public Billet hentEnBillet(int id)
        {
            if (id == 0)
            {
                var billet = new Billet();
                billet.BId = 0;
                return billet;
            }
            else
            {
                var billet = new Billet()
                {
                    BId = 1,
                    FraogTiltur = "10:30-12:30",
                    Price = 299,
                    StrekningId = 1




                };
                return billet;
            }


        }


    }
    //check branches

    
}
