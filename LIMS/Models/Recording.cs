using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LIMS.Models
{
    public class Recording
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int RecordingId { get; set; }

        [Display(Name="Creator")]
        public int UserProfileId { get; set; }
        public virtual UserProfile UserProfile { get; set; }

        [Display(Name="Subject")]
        public int SubjectId { get; set; }
        public virtual Subject Subject { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name="Creation Time")]
        public DateTime CreationTime { get; set; }

        [DataType(DataType.MultilineText)]
        public string Notes { get; set; }

        public virtual List<RecordingHistoryItem> ModificationHistory { get; set; }
        public virtual List<ProtocolTimelineItem> Timeline { get; set; }
        
    }
}