using FicticiusEventos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApp.Models;

namespace ProSorteio.Models
{
    public class People : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Cpf { get; set; }
        public string Sex { get; set; }
        public virtual ICollection<Member> Members { get; set; }
        public List<PeopleSweepstake> PeopleSweepstakes { get; set; }
        public virtual Member Member { get; set; }


    }
}
