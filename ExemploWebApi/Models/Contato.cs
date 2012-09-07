using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ExemploWebApi.Models
{
    public class Contato
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(30)]
        public string PrimeiroNome { get; set; }
        [Required]
        [StringLength(30)]
        public string UltimoNome { get; set; }
        [Required]
        [StringLength(120)]
        public string Email { get; set; }
    }
}