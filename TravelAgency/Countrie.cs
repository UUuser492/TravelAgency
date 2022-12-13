using Castle.Components.DictionaryAdapter;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KeyAttribute = System.ComponentModel.DataAnnotations.KeyAttribute;

namespace TravelAgency
{
    public class Countrie
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        //public Countrie(int id, string name)
        //{
        //    Id = id;
        //    Name = name;
        //}
    }
}
