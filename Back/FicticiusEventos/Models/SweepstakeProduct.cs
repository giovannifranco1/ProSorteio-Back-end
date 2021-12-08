using ProSorteio.Models;

namespace FicticiusEventos.Models
{
    public class SweepstakeProduct
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int SweepstakeId { get; set; }  
        public int Quantities { get; set; }
        public Product Product { get; set; }
        public Sweepstake Sweepstake { get; set; }

    }
}
