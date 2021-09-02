using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFinder.Data
{
    public class GameSystem
    {
        [Key]
        [Range(1,4)]
        public int Id { get; set; }
        [Required]
        public string SystemTitle
        {
            get;  set;

        }

        [ForeignKey(nameof(Game))]
        public int GameId { set { } }
        public virtual Game Game { get; set; }
    }
}
