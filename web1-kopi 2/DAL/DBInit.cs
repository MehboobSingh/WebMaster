
using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Gruppeoppgave1.DAL
{


    public class DBInit
    {

        public static void Initialize(IApplicationBuilder app)

        {
            var serviceScope = app.ApplicationServices.CreateScope();

                var db = serviceScope.ServiceProvider.GetService<DBContext>();
               
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();
               
                var nystrekning1 = new Strekninger
                {
                    Fra = "Oslo",
                    Til = "Bergen"
                };
                var nystrekning2 = new Strekninger
                {
                    Fra = "Oslo",
                    Til = "Stavanger"
                };

                var nystrekning3 = new Strekninger
                {
                    Fra = "Bergen",
                    Til = "Oslo"
                };



                var nystrekning4 = new Strekninger
                {
                    Fra = "Stavanger",
                    Til = "Oslo"
                };



                var nystrekning5 = new Strekninger
                {
                    Fra = "Trondiheim",
                    Til = "Oslo"
                };

            var nystrekning6 = new Strekninger
            {
                Fra = "Trond",
                Til = "Oslo"
            };

            





            var nyavgang1 = new Billeter
                {

                    FraogTiltur = "10:30-12:30",

                    Price = 299,
                    StrekningId = 1

                };
                var nyavgang2 = new Billeter
                {

                    FraogTiltur = "10:30-1330",

                    Price = 399,
                    StrekningId = 1

                };
                var nyavgang3 = new Billeter
                {

                    FraogTiltur = "10:30-14:30",

                    Price = 399,
                    StrekningId = 2
                };

                var nyavgang4 = new Billeter
                {

                    FraogTiltur = "09:30-1530",

                    Price = 399,
                    StrekningId = 2

                };
                var nyavgang5 = new Billeter
                {

                    FraogTiltur = "08:30-16:30",

                    Price = 499,
                    StrekningId = 3
                };

                var nyavgang6 = new Billeter
                {

                    FraogTiltur = "15:30-21:30",

                    Price = 599,
                    StrekningId = 3

                };


                var nyavgang7 = new Billeter

                {

                    FraogTiltur = "13:00-1900",

                    Price = 449,
                    StrekningId = 4


                };

                var nyavgang8 = new Billeter
                {

                    FraogTiltur = "14:30-20:30",

                    Price = 499,
                    StrekningId = 4


                };

                var nyavgang9 = new Billeter
                {
                    FraogTiltur = "08:30-14:00",
                    Price = 599,
                    StrekningId = 5

                };
            var nyavgang10 = new Billeter
            {
                FraogTiltur = "08:30-14:00",
                Price = 599,
                StrekningId = 5

            };





           


            var nybilleter = new List<Billeter>();
                nybilleter.Add(nyavgang1);
                nybilleter.Add(nyavgang2);
                nybilleter.Add(nyavgang3);
                nybilleter.Add(nyavgang4);
                nybilleter.Add(nyavgang5);
                nybilleter.Add(nyavgang6);
                nybilleter.Add(nyavgang7);
                nybilleter.Add(nyavgang8);
                nybilleter.Add(nyavgang9);
                nybilleter.Add(nyavgang10);

            var nystrekning = new List<Strekninger>();
                nystrekning.Add(nystrekning1);
                nystrekning.Add(nystrekning2);
                nystrekning.Add(nystrekning3);
                nystrekning.Add(nystrekning4);
                nystrekning.Add(nystrekning5);
                nystrekning.Add(nystrekning6);



            db.Billeter.AddRange(nybilleter);
                db.Strekninger.AddRange(nystrekning);

                db.SaveChanges();
            }
        }
    }
    