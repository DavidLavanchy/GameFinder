using GameFinder.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFinder.Models.GameModels
{
    public class GameEdit
    {
        [Required]
        public int Id { get; set; }
        public string Title { get; set; }

        public string Description { get; set; }
 
        public string Rating { get; set; }

        public ICollection<GameSystem> GameSystems { get; set; }

        public ICollection<Genre> Genres { get; set; }
        public decimal Price { get; set; }
        public bool MultiPlayer { get; set; }
    }
}
