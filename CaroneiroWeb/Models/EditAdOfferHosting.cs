using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CaroneiroWeb.Models
{
    public class EditAdOfferHosting
    {
        public int id_advertisement { get; set; }// Em uso

        [Required(ErrorMessage = "Informe uma data de validade para seu anúncio.")]
        [Display(Name = "Validade do anúncio")]
        [DataType(DataType.Date)]
        public DateTime expiration_date { get; set; }//Em uso

        [Required(ErrorMessage = "Informe um título para o seu anúncio")]
        [StringLength(50, ErrorMessage = "Utilize até 50 caracteres.")]
        public string title { get; set; }// Em uso

        [Required(ErrorMessage = "Informe qual o estado.")]
        [StringLength(50, ErrorMessage = "Utilize até 50 caracteres.")]
        [Display(Name = "Estado")]
        public string state { get; set; }//Em uso

        [Required(ErrorMessage = "Informe qual a cidade.")]
        [StringLength(45, ErrorMessage = "Utilize até 45 caracteres.")]
        [Display(Name = "Cidade")]
        public string city { get; set; }//Em uso

        [Required(ErrorMessage = "Informe a data de início.")]
        [Display(Name = "De")]
        [DataType(DataType.Date)]
        public DateTime start { get; set; } //Em uso

        [Display(Name = "Checkin")]
        [DataType(DataType.Date)]
        public DateTime checkin { get; set; }//Em uso - no banco equivale a start

        [Display(Name = "Checkout")]
        [DataType(DataType.Date)]
        public DateTime checkout { get; set; }//Em uso - no banco equivale a end

        [Required(ErrorMessage = "Informe a data final.")]
        [Display(Name = "Até")]
        [DataType(DataType.Date)]
        public DateTime end { get; set; } // Em uso

        [Required(ErrorMessage = "Informe a quantidade de pessoas.")]
        [Display(Name = "Quantidade de pessoas")]
        public int quantity_people { get; set; }//Em uso

        [Required(ErrorMessage = "Informe o valor diário por pessoa.")]
        [Display(Name = "Valor diário por pessoa")]
        public double maximum_people_value { get; set; }//Em uso

        [Required(ErrorMessage = "Informe o tipo de acomodação disponível.")]
        [StringLength(50, ErrorMessage = "Utilize até 50 caracteres.")]
        [Display(Name = "Tipo de acomodação")]
        public string accommodation_type { get; set; }//Em uso

        [Display(Name = "Deixe alguma informação para completar seu anúncio")]
        public string description { get; set; }

        public int id_owner_ad { get; set; }
    }
}