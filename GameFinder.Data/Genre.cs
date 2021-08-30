using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFinder.Data
{
    public class Genre
    {
        [Key]
        [Range(1, 10)]
        public int Id { get; set; }
        [Required]
        public string GenreType
        {
            set
            {
                if (this.Id == 1)
                {
                    this.GenreType = "RPG";
                }
                if (this.Id == 2)
                {
                    this.GenreType = "MMO";
                }
                if (this.Id == 3)
                {
                    this.GenreType = "First-Person Shooter";
                }
                if (this.Id == 4)
                {
                    this.GenreType = "Sports";
                }
                if (this.Id == 5)
                {
                    this.GenreType = "Adventure";
                }
                if (this.Id == 6)
                {
                    this.GenreType = "Action";
                }
                if (this.Id == 7)
                {
                    this.GenreType = "Racing";
                }
                if (this.Id == 8)
                {
                    this.GenreType = "Strategy";
                }
                if (this.Id == 9)
                {
                    this.GenreType = "Racing";
                }
                if (this.Id == 10)
                {
                    this.GenreType = "Survival";
                }
            }

        }
        [Required]
        public string Description { get; set; }

        [ForeignKey(nameof(Game))]
        public int GameId { get; set; }
        public virtual Game Game { get; set; }
    }
}
