using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoLayer.Feature
{
    public class GetCarFeatureByCarDto
    {
        public int FeatureID { get; set; }
        public int CarID { get; set; }
        public string Name { get; set; }
        public bool Available { get; set; }
    }
}
