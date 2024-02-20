using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoLayer.RentACar
{
    public class ResultRentACarIdDto
    {
        public int CarID { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string CoverImage { get; set; }
        public int Km { get; set; }
        public string Transmission { get; set; }
        public int Seat { get; set; }
        public int Luggage { get; set; }
        public string Fuel { get; set; }
        public string BigImageUrl { get; set; }
    }
}
