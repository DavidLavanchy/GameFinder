using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFinder.Data
{
    public class Game
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Rating { get; set; }
        [Required]
        public ICollection<GameSystem> GameSystems { get; set; } = new List<GameSystem>();
        [Required]
        public ICollection<Genre> Genres { get; set; } = new List<Genre>();
        public decimal Price { get; set; }
        public bool MultiPlayer { get; set; }
    }
}
