using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LIMS.Models
{
    public class Booking
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int BookingId { get; set; }

        public DateTime StartTime { get; set; }

        public TimeSpan Duration { get; set; }

        [Display(Name="User")]
        public int UserProfileId { get; set; }
        public virtual UserProfile UserProfile { get; set; }

        [Display(Name = "Asset")]
        public int LabAssetId { get; set; }
        public virtual LabAsset LabAsset { get; set; }

    }
}