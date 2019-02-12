using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public class SubstationEntity
    {
        string id;
        string name;
        string x;
        string y;

        public string Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string X { get => x; set => x = value; }
        public string Y { get => y; set => y = value; }

        public SubstationEntity(string id, string name, string x, string y)
        {
            this.Id = id;
            this.Name = name;
            this.X = x;
            this.Y = y;
        }
    }
}
