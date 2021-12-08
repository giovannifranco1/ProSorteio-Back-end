using FicticiusEventos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApp.Models;

namespace ProSorteio.Models
{
    public class Product : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public string Description { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<Sweepstake> Sweepstakes{ get; set; }
        public List<SweepstakeProduct> SweepstakeProducts { get; set; }

    }
}