using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFinder.Models.GenreModels
{
    public class GenreCreate
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string GenreType { get; set; }

        [Required]
        public string Description { get; set; }
    }
}
