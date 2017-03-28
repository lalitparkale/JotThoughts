using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Jot.Models
{
    public class JotCardModel
    {
        [Key]
        public int jotID { get; set; }

        public string jottedThought { get; set; }

        public string contactEmail { get; set; }

        public string contactPhone { get; set; }

        public string contactConsent { get; set; }

        public string ReferrerURL { get; set; }

        public string ReferrerContext { get; set; }

        public CardPropertyModel CardAttributes { get; set; }

        public DateTime Created { get; set; }
    }
}