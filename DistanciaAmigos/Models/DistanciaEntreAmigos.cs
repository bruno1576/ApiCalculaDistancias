using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DistanciaAmigos.Models
{
    public class DistanciaEntreAmigos
    {
        public int Id { get; set; }
        public float X { get; set; }
        public float Y { get; set; }
        public int AmigoId { get; set; }
        public virtual Amigo Amigo { get; set; }
    }
}
