using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GameManager.Models
{
    public class GameModel : Controller
    {
        [Key]
        public int id { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string platform { get; set; }
        [Required]
        public string publisher { get; set; }
        public IActionResult Index()
        {
            return View();
        }
    }
}
