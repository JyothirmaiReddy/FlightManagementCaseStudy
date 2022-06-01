using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AirLineAPIService.Models
{
    public class Airline
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AirlineNo { get; set; }
        public string airlineLogo { get; set; }
        public int contactNumber { get; set; }
        public string contactAddress { get; set; }
        public bool IsBlocked { get; set; }
        public ICollection<Inventory> Inventories { get; set; }
    }
}
