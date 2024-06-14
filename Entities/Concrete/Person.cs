using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Person
    {
        public int Id { get; set; }
        public string Ci { get; set; }
        public string Name { get; set; }
        public int PersonTypeId { get; set; }
        public PersonType PersonType { get; set; }
        public string Lat { get; set; }
        public string Lon { get; set; }
    }
}
