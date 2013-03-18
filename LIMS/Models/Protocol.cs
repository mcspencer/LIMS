using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace LIMS.Models
{
    public class Protocol
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ProtocolId { get; set; }

        [DataType(DataType.MultilineText)]
        public string Text { get; set; }
    }
}
