using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFinder.Models.GameSystemModels
{
    public class GameSystemCreate
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string SystemTitle { get; }
    }
}
