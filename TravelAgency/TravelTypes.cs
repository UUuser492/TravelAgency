using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency
{
    public class TravelTypes
    {

        public int Id { get; set; }
        public string Types { get; set; }

        public TravelTypes(int id , string type)
        {
            Id = id;
            Types = type;
        }


    }
}
