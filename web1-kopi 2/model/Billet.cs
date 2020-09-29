using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Gruppeoppgave1.model
{
    public class Billet
    {


      [Key]
     
    public int BId { get; set; }

        

        [Required]
        [RegularExpression(@"[a-zA-ZæøåÆØÅ. \-]{2,20}")]
        public string FraogTiltur{ get; set; }


       

        [Required]
        [DataType(DataType.Date)]
        public DateTime DateFra { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DateRetur { get; set; }

        public string Type { get; set; }

        [RegularExpression(@"[a-zA-ZæøåÆØÅ. \-]{2,20}")]
        public double Price { get; set; }
        public int StrekningId { get; set; }

       

        // check branches

    }

}

