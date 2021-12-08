using ProSorteio.Models;

namespace FicticiusEventos.Models
{
    public class PeopleSweepstake
    {
        public int Id { get; set; }
        public int PeopleId { get; set; }
        public int SweepstakeId { get; set;}
        public Sweepstake Sweepstake { get; set; }
        public People People { get; set; }
    }
}
