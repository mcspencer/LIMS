using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LIMS.Models
{
    public class SubjectType
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int SubjectTypeId { get; set; }

        public string Name { get; set; }
        
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        public virtual List<Subject> Subjects { get; set; }
    }
}