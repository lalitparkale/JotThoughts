using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Jot.Models
{
    public class CardPropertyModel
    {
        [DefaultValue(1)]
        public int enableContactEmail {get; set;}

        [DefaultValue(0)]
        public int enableContactConsent { get; set; }

        [DefaultValue(false)]
        public bool enableCaptcha { get; set; }

        [DefaultValue(500)]
        public int maxJotLength { get; set; }

        public static int ultimateJotLength = 5000;

        [DefaultValue(0)]
        public int enableAttachment { get; set; }

        [DefaultValue(5)]
        public int maxAttachmentSize { get; set; }

        [DefaultValue(0)]
        public int enableVoice { get; set; }

        [DefaultValue(3)]
        public int maxVoiceRecLen { get; set; }

        [DefaultValue(1)]
        public int showContextTags { get; set; }

        public string ReferrerURL { get; set; }

        public string ReferrerContext { get; set; }
    }
}