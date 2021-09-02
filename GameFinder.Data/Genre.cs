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
            get;  set;
        }
        [Required]
        public string Description { get; set; }

        [ForeignKey(nameof(Game))]
        public int GameId { get; set; }
        public virtual Game Game { get; set; }
    }
}
