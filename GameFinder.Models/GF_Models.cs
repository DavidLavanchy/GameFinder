using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace GameFinder.Models
{
    class GF_Models
    {
        public string GameID { get; set; }
        public decimal PriceRange { get; set; }
        public string Rating { get; set; }
        public string system { get; set; }
        public string GameTitle { get; set; }
    }
}
