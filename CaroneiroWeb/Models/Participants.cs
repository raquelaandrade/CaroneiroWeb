using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CaroneiroWeb.Models
{
    public class Participants
    {
        public int id_participantsads { get; set; }

        public DateTime date_participant { get; set; }

        public string title { get; set; }

        public int id_advertisement { get; set; }

        public int id_user { get; set; }

        public int id_owner_ad { get; set; }

        public Users User { get; set; }
    }
}