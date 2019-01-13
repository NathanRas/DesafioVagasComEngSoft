using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DesafioVagasComEngSoft
{
    public class Node
    {
        public string Name { get; set; }
        public List<Neighbor> neighborList { get; set; }

        public XDocument xdoc { get; set; }

        public Node()
        {
            this.Name = string.Empty;
            this.neighborList = new List<Neighbor>();
            string pathFileXml = System.Web.Hosting.HostingEnvironment.MapPath(@"~/Data/Nodes.xml");
            if (string.IsNullOrEmpty(pathFileXml))
            {
                pathFileXml = "../../Nodes.xml";
            }
            this.xdoc = XDocument.Load(pathFileXml);
        }

        public bool IsLeaf
        {
            get{
                if (this.neighborList.Count == 1)
                {
                    return true;
                }
                return false;
            }
        }


        public void GetNodeByName(string name)
        {
            XElement element = this.xdoc.Descendants("Node").FirstOrDefault(x => x.Element("Name").Value.ToUpper() == name.ToUpper());

            this.Name = name.ToUpper();
            //var node = new Node();
            //node.Name = name.ToUpper();

            var neighborsElements = element?.Elements("Neighbor");

            foreach (var neig in neighborsElements)
            {
                var neighbor = new Neighbor();
                neighbor.Name = neig.Element("Name").Value.ToUpper();
                neighbor.Distance = Convert.ToInt32(neig.Element("Distance").Value);
                string pKey = neig.Element("Name").Value;
                int pValue = Convert.ToInt32(neig.Element("Distance").Value);
                this.neighborList.Add(neighbor);
            }

            //return node;
        }

        public bool CheckIfNodeExist(string name)
        {
            XElement element = xdoc.Descendants("Node").FirstOrDefault(x => x.Element("Name").Value.ToUpper() == name.ToUpper());

            if (element == null) return false;

            return true;
        }
    }
}
