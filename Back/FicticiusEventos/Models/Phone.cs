using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApp.Models;

namespace ProSorteio.Models
{
    public class Phone : BaseEntity
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public int PeopleId { get; set; }
    }
}
