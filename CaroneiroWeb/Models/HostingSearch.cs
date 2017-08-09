﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CaroneiroWeb.Models
{
    public class HostingSearch
    {
        [Required]
        [Display(Name = "Estado")]
        public string state { get; set; }//Em uso

        [Required]
        [Display(Name = "Cidade")]
        public string city { get; set; }//Em uso
    }
}