﻿using System;
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
        public List<GameSystem> GameSystems { get; set; }
        [Required]
        public List<Genre> Genres { get; set; }
        public decimal Price { get; set; }
        public bool MultiPlayer { get; set; }
    }
}
