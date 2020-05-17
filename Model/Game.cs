using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
namespace VGListRazor.Model
{
    public class Game
    {
        [Key]
        public int id { get; set; }

        [Required]
        public string Name { get; set; }
        public string platform { get; set; }
        public string publisher{ get; set; }
    }
}