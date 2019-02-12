using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public class NodeEntity
    {
        string id;
        string name;
        string x;
        string y;

        public NodeEntity(string id, string name, string x, string y)
        {
            this.id = id;
            this.name = name;
            this.x = x;
            this.y = y;
        }

        public string Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string X { get => x; set => x = value; }
        public string Y { get => y; set => y = value; }
    }
}
