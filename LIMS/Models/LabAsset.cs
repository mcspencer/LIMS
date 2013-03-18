using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LIMS.Models
{
    public class LabAsset
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int LabAssetId { get; set; }

        [DataType(DataType.Text)]
        public string Name { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime Created { get; set; }

        [Display(Name = "Asset type")]
        public int LabAssetTypeId { get; set; }
        public virtual LabAssetType Type { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Display(Name="Needs Attention")]
        public bool NeedsAttention { get; set; }
    }
}