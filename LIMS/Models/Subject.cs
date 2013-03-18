using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LIMS.Models
{
    public class Subject
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int SubjectId { get; set; }

        [DataType(DataType.Text)]
        public string Name { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name="Created")]
        public DateTime Created { get; set; }

        [Display(Name="Created by")]
        public int UserProfileId { get; set; }
        public virtual UserProfile UserProfile { get; set; }

        [Display(Name="Subject type")]
        public int SubjectTypeId { get; set; }
        public virtual SubjectType SubjectType { get; set; }

        [DataType(DataType.MultilineText)]
        public string Notes { get; set; }
    }
}