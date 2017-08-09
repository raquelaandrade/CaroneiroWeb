using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CaroneiroWeb.Models
{
    public class Advertisement
    {
        public int id_advertisement { get; set; }// Em uso

        
        public string type_ad { get; set; }// Em uso

        public DateTime date_creation { get; set; }//Em uso

        [Display(Name = "Validade do anúncio")]
        [DataType(DataType.Date)]
        public DateTime expiration_date { get; set; }//Em uso

        [StringLength(50, ErrorMessage = "Utilize até 50 caracteres.")]
        public string title { get; set; }// Em uso

        [Display(Name = "Estado")]
        [StringLength(50, ErrorMessage = "Utilize até 50 caracteres.")]
        public string state { get; set; }//Em uso

        [Display(Name = "Cidade")]
        [StringLength(45, ErrorMessage = "Utilize até 45 caracteres.")]
        public string city { get; set; }//Em uso

        [Display(Name ="Cidade")]
        [StringLength(45, ErrorMessage = "Utilize até 45 caracteres.")]
        public string exitTown { get; set; }//Em uso

        [Display(Name = "Estado")]
        [StringLength(50, ErrorMessage = "Utilize até 50 caracteres.")]
        public string exitState { get; set; }//Em uso

        [Display(Name ="De")]
        [DataType(DataType.Date)]
        public DateTime start { get; set; } //Em uso

        [Display(Name ="Até")]
        [DataType(DataType.Date)]
        public DateTime end { get; set; } // Em uso

        [Display(Name = "Checkin")]
        [DataType(DataType.Date)]
        public DateTime checkin { get; set; }//Em uso - no banco equivale a start

        [Display(Name = "Checkout")]
        [DataType(DataType.Date)]
        public DateTime checkout { get; set; }//Em uso - no banco equivale a end

        [Display(Name = "Tipo de acomodação")]
        [StringLength(50, ErrorMessage = "Utilize até 50 caracteres.")]
        public string accommodation_type { get; set; }//Em uso

        [Display(Name = "Quantidade de pessoas")]
        public int quantity_people { get; set; }//Em uso

        [Display(Name = "Valor diário por pessoa")]
        public double maximum_people_value { get; set; }//Em uso

        [Display(Name = "Valor por pessoa no trajeto")]
        public double maximum_route_value { get; set; } //Em uso

        [Display(Name = "Quantidade de bagagens")]
        public int baggage_allowance { get; set; }

        [Display(Name = "Local de Saída")]
        [StringLength(45, ErrorMessage = "Utilize até 45 caracteres.")]
        public string local_exit { get; set; }//Em uso

        [Display(Name = "Data da saída")]
        [DataType(DataType.Date)]
        public DateTime departure_date { get; set; } // Em uso

        [Display(Name = "Finalidade ")]
        [StringLength(100, ErrorMessage = "Utilize até 100 caracteres.")]
        public string finality { get; set; } // Em uso

        [Display(Name = "Deixe alguma informação para completar seu anúncio")]
        public string description { get; set; }
        
        public int active { get; set; }


        public int disabled { get; set; }

 
        public int id_owner_ad { get; set; }

        public Users User { get; set; }

        public Advertisement()
        {

        }

    }
}