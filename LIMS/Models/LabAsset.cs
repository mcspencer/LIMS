using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
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

        [DataType(DataType.Date)]
        public DateTime Created { get; set; }

        //[Display(Name = "Asset type")]
        //public int LabAssetTypeId { get; set; }
        //public virtual LabAssetType Type { get; set; }

        [Display(Name="Tags")]
        [DataType(DataType.Text)]
        public virtual ICollection<LabAssetTag> LabAssetTags { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Display(Name="Needs Attention")]
        public bool NeedsAttention { get; set; }

        public LabAsset()
        {
            LabAssetTags = new HashSet<LabAssetTag>();
        }

        /// <summary>
        /// Converts the list of tag objects into a comma-separated string
        /// </summary>
        /// <returns></returns>
        public string GetTagString()
        {
            StringBuilder tags = new StringBuilder();

            foreach (LabAssetTag tag in this.LabAssetTags)
            {
                tags.Append(tag.Name + ", ");
            }

            if (this.LabAssetTags.Count > 0)
            {
                // Remove the trailing comma
                tags.Remove(tags.Length - 2, 2);
            }
            return tags.ToString();
        }

        public void AddTags(string tags)
        {
        }
    }
}