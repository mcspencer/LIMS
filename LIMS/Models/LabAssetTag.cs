using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LIMS.Models
{
    public class LabAssetTag
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int LabAssetTagId { get; set; }

        [DataType(DataType.Text)]
        public string Name { get; set; }

        public virtual ICollection<LabAsset> LabAssets { get; set; }

        public LabAssetTag()
        {
            LabAssets = new HashSet<LabAsset>();
        }
    }
}