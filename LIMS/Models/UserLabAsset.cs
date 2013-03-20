using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LIMS.Models
{
    public class UserLabAsset
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int UserLabAssetId { get; set; }

        [Display(Name="User")]
        public int UserProfileId { get; set; }
        public virtual UserProfile UserProfile { get; set; }

        [Display(Name="Asset")]
        public int LabAssetId { get; set; }
        public virtual LabAsset LabAsset { get; set; }

        [Display(Name = "Favourite?")]
        public bool IsFavourite { get; set; }

        [Display(Name = "Last viewed")]
        public DateTime LastViewed { get; set; }

        [Display(Name = "Last modified")]
        public DateTime LastChanged { get; set; }
    }
}