namespace DesafioVagasComEngSoft
{
    public class PathGraph
    {
        public string Nodes { get; set; }

        public  int TotalDistance { get; set; }
        public PathGraph(string nodes,int distance = 0)
        {
            this.Nodes = nodes;
            this.TotalDistance = distance;
        }
    }
}