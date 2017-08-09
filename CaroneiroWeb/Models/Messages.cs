using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CaroneiroWeb.Models
{
    public class Messages
    {
        public int id_message { get; set; }

        [Required(ErrorMessage ="Você precisa inserir algum texto...")]
        [DataType(DataType.MultilineText)]
        public string content { get; set; }

        public DateTime date_msg { get; set; }

        public int to_user_id { get; set; }

        public int from_user_id { get; set; }

        public Users User { get; set; }

    }
}