using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Client
{
    public static class XMLFunctions
    {
        public static List<SubstationEntity> ReadSubstations()
        {
            List<SubstationEntity> ret = new List<SubstationEntity>();
            string id = "";
            string name = "";
            string x = "";
            string y = "";

            using (XmlReader reader = XmlReader.Create(AppDomain.CurrentDomain.BaseDirectory + "Geographic.xml"))
            {
                while (reader.Read())
                {

                    if (reader.IsStartElement() && reader.Name.Equals("SubstationEntity"))
                    {
                        while (true)
                        {
                            if (reader.Name.Equals("Id"))
                            {
                                reader.Read();
                                id = reader.Value;
                                break;
                            }
                            else
                            {
                                reader.Read();
                            }
                        }

                        while (true)
                        {

                            if (reader.Name.Equals("Name"))
                            {
                                reader.Read();
                                name = reader.Value;
                                break;
                            }
                            else
                            {
                                reader.Read();
                            }
                        }

                        while (true)
                        {
                            if (reader.Name.Equals("X"))
                            {
                                reader.Read();
                                x = reader.Value;
                                break;
                            }
                            else
                            {
                                reader.Read();
                            }
                        }

                        while (true)
                        {
                            if (reader.Name.Equals("Y"))
                            {
                                reader.Read();
                                y = reader.Value;

                                SubstationEntity s = new SubstationEntity(id, name, x, y);
                                ret.Add(s);
                                break;
                            }
                            else
                            {
                                reader.Read();
                            }
                        }

                    }
                    if (reader.NodeType == XmlNodeType.EndElement && reader.Name.Equals("Substations"))
                        return ret;
                }
            }
            return ret;
        }

        public static List<NodeEntity> ReadNodes()
        {
            List<NodeEntity> ret = new List<NodeEntity>();
            string id = "";
            string name = "";
            string x = "";
            string y = "";

            using (XmlReader reader = XmlReader.Create(AppDomain.CurrentDomain.BaseDirectory + "Geographic.xml"))
            {
                while (reader.Read())
                {

                    if (reader.IsStartElement() && reader.Name.Equals("NodeEntity"))
                    {
                        while (true)
                        {
                            if (reader.Name.Equals("Id"))
                            {
                                reader.Read();
                                id = reader.Value;
                                break;
                            }
                            else
                            {
                                reader.Read();
                            }
                        }

                        while (true)
                        {

                            if (reader.Name.Equals("Name"))
                            {
                                reader.Read();
                                name = reader.Value;
                                break;
                            }
                            else
                            {
                                reader.Read();
                            }
                        }

                        while (true)
                        {
                            if (reader.Name.Equals("X"))
                            {
                                reader.Read();
                                x = reader.Value;
                                break;
                            }
                            else
                            {
                                reader.Read();
                            }
                        }

                        while (true)
                        {
                            if (reader.Name.Equals("Y"))
                            {
                                reader.Read();
                                y = reader.Value;

                                NodeEntity s = new NodeEntity(id, name, x, y);
                                ret.Add(s);
                                break;
                            }
                            else
                            {
                                reader.Read();
                            }
                        }

                    }
                    if (reader.NodeType == XmlNodeType.EndElement && reader.Name.Equals("Nodes"))
                        return ret;
                }
            }
            return ret;
        }

        public static List<SwitchEntity> ReadSwitches()
        {
            List<SwitchEntity> ret = new List<SwitchEntity>();
            string id = "";
            string name = "";
            string status = "";
            string x = "";
            string y = "";

            using (XmlReader reader = XmlReader.Create(AppDomain.CurrentDomain.BaseDirectory + "Geographic.xml"))
            {
                while (reader.Read())
                {

                    if (reader.IsStartElement() && reader.Name.Equals("SwitchEntity"))
                    {
                        while (true)
                        {
                            if (reader.Name.Equals("Id"))
                            {
                                reader.Read();
                                id = reader.Value;
                                break;
                            }
                            else
                            {
                                reader.Read();
                            }
                        }

                        while (true)
                        {

                            if (reader.Name.Equals("Name"))
                            {
                                reader.Read();
                                name = reader.Value;
                                break;
                            }
                            else
                            {
                                reader.Read();
                            }
                        }

                        while (true)
                        {

                            if (reader.Name.Equals("Status"))
                            {
                                reader.Read();
                                status = reader.Value;
                                break;
                            }
                            else
                            {
                                reader.Read();
                            }
                        }

                        while (true)
                        {
                            if (reader.Name.Equals("X"))
                            {
                                reader.Read();
                                x = reader.Value;
                                break;
                            }
                            else
                            {
                                reader.Read();
                            }
                        }

                        while (true)
                        {
                            if (reader.Name.Equals("Y"))
                            {
                                reader.Read();
                                y = reader.Value;

                                SwitchEntity s = new SwitchEntity(id, name, status, x, y);
                                ret.Add(s);
                                break;
                            }
                            else
                            {
                                reader.Read();
                            }
                        }

                    }
                    if (reader.NodeType == XmlNodeType.EndElement && reader.Name.Equals("Switches"))
                        return ret;
                }
            }
            return ret;
        }


        public static List<LineEntity> ReadLines()
        {
            List<LineEntity> ret = new List<LineEntity>();
            using (XmlReader reader = XmlReader.Create(AppDomain.CurrentDomain.BaseDirectory + "Geographic.xml"))
            {
                while (reader.Read())
                {
                    if (reader.IsStartElement() && reader.IsStartElement("LineEntity"))
                    {
                        LineEntity s = new LineEntity();
                        Vertices v = new Vertices();

                        while (true)
                        {
                            if (reader.Name.Equals("Id"))
                            {
                                reader.Read();
                                s.Id = reader.Value;
                                break;
                            }
                            else
                            {
                                reader.Read();
                            }
                        }

                        while (true)
                        {
                            if (reader.Name.Equals("Name"))
                            {
                                reader.Read();
                                s.Name = reader.Value;
                                break;
                            }
                            else
                            {
                                reader.Read();
                            }
                        }

                        while (true)
                        {
                            if (reader.Name.Equals("IsUnderground"))
                            {
                                reader.Read();
                                s.IsUnderground = reader.Value;
                                break;
                            }
                            else
                            {
                                reader.Read();
                            }
                        }

                        while (true)
                        {
                            if (reader.Name.Equals("R"))
                            {
                                reader.Read();
                                s.R = reader.Value;
                                break;
                            }
                            else
                            {
                                reader.Read();
                            }
                        }

                        while (true)
                        {
                            if (reader.Name.Equals("ConductorMaterial"))
                            {
                                reader.Read();
                                s.ConductorMaterial = reader.Value;
                                break;
                            }
                            else
                            {
                                reader.Read();
                            }
                        }

                        while (true)
                        {
                            if (reader.Name.Equals("LineType"))
                            {
                                reader.Read();
                                s.LineType = reader.Value;
                                break;
                            }
                            else
                            {
                                reader.Read();
                            }
                        }

                        while (true)
                        {
                            if (reader.Name.Equals("ThermalConstantHeat"))
                            {
                                reader.Read();
                                s.ThermalConstantHeat = reader.Value;
                                break;
                            }
                            else
                            {
                                reader.Read();
                            }
                        }

                        while (true)
                        {
                            if (reader.Name.Equals("FirstEnd"))
                            {
                                reader.Read();
                                s.FirstEnd = reader.Value;
                                break;
                            }
                            else
                            {
                                reader.Read();
                            }
                        }

                        while (true)
                        {
                            if (reader.Name.Equals("SecondEnd"))
                            {
                                reader.Read();
                                s.SecondEnd = reader.Value;
                                break;
                            }
                            else
                            {
                                reader.Read();
                            }
                        }

                        while (reader.Read())
                        {
                            if (reader.IsStartElement() && reader.IsStartElement("Point"))
                            {

                                Point p = new Point();
                                while (true)
                                {
                                    if (reader.Name.Equals("X"))
                                    {
                                        reader.Read();
                                        p.X = reader.Value;
                                        break;
                                    }
                                    else
                                    {
                                        reader.Read();
                                    }
                                }

                                while (true)
                                {
                                    if (reader.Name.Equals("Y"))
                                    {
                                        reader.Read();
                                        p.Y = reader.Value;
                                        break;
                                    }
                                    else
                                    {
                                        reader.Read();
                                    }
                                }

                                v.Points.Add(p);

                            }

                            if (reader.NodeType == XmlNodeType.EndElement && reader.Name.Equals("LineEntity"))
                            {
                                s.Vertice = v;
                                ret.Add(s);
                                break;
                            }
                        }
                    }
                }

                return ret;
            }
        }
    }
}
