using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CaroneiroWeb.Models
{
    public class Contact
    {
        [Required]
        [Display(Name = "Nome")]
        public string name { get; set; }//Em uso

        [Required]
        [Display(Name = "Email")]
        public string email { get; set; }//Em uso

        [Required]
        [Display(Name = "Assunto")]
        public string topic { get; set; }//Em uso

        [Required]
        [Display(Name = "Mensagem")]
        public string message { get; set; }//Em uso

    }
}