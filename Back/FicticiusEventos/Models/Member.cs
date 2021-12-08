using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApp.Models;

namespace ProSorteio.Models
{
    public class Member : BaseEntity
    {
        public int Id { get; set; }
        public string Resgistration { get; set; }
        public int PeopleId { get; set; }
        public string Senha { get; set; }
        public virtual People People { get; set; }
     
    }
}
