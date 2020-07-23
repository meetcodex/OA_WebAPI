using System;
using System.Collections.Generic;
using System.Text;

namespace OA_DataAccess
{
    public class Country : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<State> states { get; set; }
    }

    public class State : BaseEntity
    {
        public string Name { get; set; }
        public Country country { get; set; }
        public int CountryId { get; set; }
        public ICollection<City> cities { get; set; }
    }

    public class City : BaseEntity
    {
        public string Name { get; set; }
        public State state { get; set; }
        public int StateId { get; set; }
    }
}
