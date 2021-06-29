using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanatOkulu.Models
{
    [Table("Sanatçılar")]
    public class Sanatci
    {
        public int Id { get; set; }
        [Required,MaxLength(100)]
        public string Ad { get; set; }
        public virtual ICollection<Eser> Eserler { get; set; }
    }
}
