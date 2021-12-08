using FicticiusEventos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApp.Models;

namespace ProSorteio.Models
{
    public class Sweepstake : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Address { get; set; }
        public int? ProductId { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public List<PeopleSweepstake> PeopleSweepstakes { get; set; }
        public List<SweepstakeProduct> SweepstakeProducts  { get; set; }

    }
}
