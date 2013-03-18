using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace LIMS.Models
{
    public class ProtocolTimelineItem
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ProtocolTimelineItemId { get; set; }

        [Display(Name="Protocol")]
        public int ProtocolId { get; set; }
        public virtual Protocol Protocol { get; set; }
        
        [Display(Name="Start time")]
        public TimeSpan StartTime { get; set; }

        [Display(Name="Stop time")]
        public TimeSpan StopTime { get; set; }

        [DataType(DataType.MultilineText)]
        public string Notes { get; set; }
    }
}
