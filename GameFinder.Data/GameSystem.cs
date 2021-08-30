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
            set
            {
                if (this.Id == 1)
                {
                    this.SystemTitle = "PlayStation";
                }
                if (this.Id == 2)
                {
                    this.SystemTitle = "Xbox";
                }
                if (this.Id == 3)
                {
                    this.SystemTitle = "PC";
                }
                if (this.Id == 4)
                {
                    this.SystemTitle = "Nintendo";
                }
            }
        }

        [ForeignKey(nameof(Game))]
        public int GameId { set { } }
        public virtual Game Game { get; set; }
    }
}
