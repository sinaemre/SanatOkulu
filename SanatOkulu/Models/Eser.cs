using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanatOkulu.Models
{
    [Table("Eserler")]
    public class Eser
    {
        public int Id { get; set; }
        [Required,MaxLength(100)]
        public string Ad { get; set; }
        public int? Yil { get; set; }
        public int SanatciId { get; set; }
        public virtual Sanatci Sanatci { get; set; }
    }
}
