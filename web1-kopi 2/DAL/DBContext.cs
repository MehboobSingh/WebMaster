using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore;

namespace Gruppeoppgave1.DAL
{

    public class Billeter
    {

        [Key]
        public int BId { get; set; }
        public string FraogTiltur { get; set; }
        public double Price { get; set; }
        public int StrekningId { get; set; }
       // public virtual Strekninger Strekning { get; set; }

    }


    public class Strekninger

    {
        

        [Key]
       
        public int SId { get; set; }
        public string Fra { get; set; }
        public string Til { get; set; }


    }



    public class DBContext : DbContext
    {
        public DBContext()
        {
        }

        public DBContext(DbContextOptions<DBContext> options) : base(options)

        {
           
            Database.EnsureCreated();


           
        }


        public virtual DbSet<Billeter> Billeter { get; set; }
        public virtual DbSet<Strekninger> Strekninger { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }
    }
}


