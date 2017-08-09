using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CaroneiroWeb.Models
{
    public class Interested
    {
        public int id_interested { get; set; }

        public string status { get; set; }

        public DateTime date_interested { get; set; }

        public string title { get; set; }

        public int id_advertisement { get; set; }

        public int id_user { get; set; }

        public int id_owner_ad { get; set; }

        public Users User { get; set; }
    }
}