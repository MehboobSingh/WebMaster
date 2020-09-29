using System;
using System.ComponentModel.DataAnnotations;

namespace Gruppeoppgave1.model
{
    public class Strekning
    {
        [Key]
        public int SId { get; set; }


        [Required]
        [RegularExpression(@"[a-zA-ZæøåÆØÅ. \-]{2,20}")]
        public string Fra { get; set; }



        [Required]
        [RegularExpression(@"[a-zA-ZæøåÆØÅ. \-]{2,20}")]
        public string Til { get; set; }

    }
}

