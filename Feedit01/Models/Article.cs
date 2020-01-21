using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Feedit01.Models
{
    public class Article
    {
        [Key]
        public long Id { get; set; }

        [Required(ErrorMessage = "Molimo unesite link")]
        [Display(Name = "Link")]
        public string Url { get; set; }

        [Required(ErrorMessage = "Molimo unesite naziv članka")]
        [StringLength(150, ErrorMessage = "Naziv može imati maksimalno 150 znakova")]
        [Display(Name = "Headline")]
        public string Headline { get; set; }

        [Required(ErrorMessage = "Molimo unesite ime autora")]
        [StringLength(50, ErrorMessage = "Ime može imati maksimalno 50 znakova")]
        [Display(Name = "Author")]
        public string Author { get; set; }

        public int Votes { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime Date { get; set; }

        public string UserId { get; set; }

        public int voteState { get; set; }

        public bool Deleted { get; set; }
    }
}