using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LIMS.Models
{
    public class RecordingHistoryItem
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int RecordingHistoryItemId { get; set; }

        [Display(Name="Recording")]
        public int RecordingId { get; set; }
        public virtual Recording Recording { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name="Modification time")]
        public DateTime ModificationTime { get; set; }

        [Display(Name = "Modified by")]
        public int UserProfileId { get; set; }
        public virtual UserProfile UserProfile { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

    }
}