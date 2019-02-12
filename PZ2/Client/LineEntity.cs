using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public class LineEntity
    {
        string id;
        string name;
        string isUnderground;
        string r;
        string conductorMaterial;
        string lineType;
        string thermalConstantHeat;
        string firstEnd;
        string secondEnd;
        Vertices vertice;

        public LineEntity(string id, string name, string isUnderground, string r, string conductorMaterial, string lineType, string thermalConstantHeat, string firstEnd, string secondEnd, Vertices vertice)
        {
            this.id = id;
            this.name = name;
            this.isUnderground = isUnderground;
            this.r = r;
            this.conductorMaterial = conductorMaterial;
            this.lineType = lineType;
            this.thermalConstantHeat = thermalConstantHeat;
            this.firstEnd = firstEnd;
            this.secondEnd = secondEnd;
            this.vertice = vertice;
        }

        public LineEntity() { }

        public string Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string IsUnderground { get => isUnderground; set => isUnderground = value; }
        public string R { get => r; set => r = value; }
        public string ConductorMaterial { get => conductorMaterial; set => conductorMaterial = value; }
        public string ThermalConstantHeat { get => thermalConstantHeat; set => thermalConstantHeat = value; }
        public string FirstEnd { get => firstEnd; set => firstEnd = value; }
        public string SecondEnd { get => secondEnd; set => secondEnd = value; }
        public Vertices Vertice { get => vertice; set => vertice = value; }
        public string LineType { get => lineType; set => lineType = value; }
    }
}
