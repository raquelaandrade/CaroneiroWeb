using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CaroneiroWeb.Models
{
    public class EditAdOfferRide
    {
        public int id_advertisement { get; set; }

        [Required(ErrorMessage = "Informe uma data de validade para seu anúncio.")]
        [Display(Name = "Validade do anúncio")]
        [DataType(DataType.Date)]
        public DateTime expiration_date { get; set; }

        [Required(ErrorMessage = "Informe um título para o seu anúncio")]
        [StringLength(50, ErrorMessage = "Utilize até 50 caracteres.")]
        public string title { get; set; }

        [Required(ErrorMessage = "Informe uma data de saída.")]
        [Display(Name = "Data da saída")]
        [DataType(DataType.Date)]
        public DateTime departure_date { get; set; }

        [Required(ErrorMessage = "Informe qual a cidade.")]
        [StringLength(50, ErrorMessage = "Utilize até 50 caracteres.")]
        [Display(Name = "Cidade")]
        public string exitTown { get; set; }

        [Required(ErrorMessage = "Informe qual o estado.")]
        [StringLength(50, ErrorMessage = "Utilize até 50 caracteres.")]
        [Display(Name = "Estado")]
        public string exitState { get; set; }

        [Required(ErrorMessage = "Informe qual o estado.")]
        [StringLength(50, ErrorMessage = "Utilize até 50 caracteres.")]
        [Display(Name = "Estado")]
        public string state { get; set; }

        [Required(ErrorMessage = "Informe qual a cidade.")]
        [StringLength(45, ErrorMessage = "Utilize até 45 caracteres.")]
        [Display(Name = "Cidade")]
        public string city { get; set; }

        [Display(Name = "Local de Saída")]
        [StringLength(45, ErrorMessage = "Utilize até 45 caracteres.")]
        public string local_exit { get; set; }

        [Required(ErrorMessage = "Informe a quantidade de pessoas.")]
        [Display(Name = "Quantidade de pessoas")]
        public int quantity_people { get; set; }

        [Required(ErrorMessage = "Informe o valor por pessoa no trajeto.")]
        [Display(Name = "Valor por pessoa no trajeto")]
        public double maximum_route_value { get; set; }

        [Display(Name = "Deixe alguma informação para completar seu anúncio")]
        public string description { get; set; }

        public int id_owner_ad { get; set; }

    }
}