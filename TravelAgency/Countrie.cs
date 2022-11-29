using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency
{
    public class Countrie
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Countrie(int id , string name)
        {
            Id = id;
            Name = name;
        }
    }
}
