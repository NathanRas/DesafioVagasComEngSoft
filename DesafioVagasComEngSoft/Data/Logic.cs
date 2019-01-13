using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioVagasComEngSoft
{
    public class Logic
    {

        /// <summary>
        /// Essa metodo faz o calul de D dependente 
        /// do valor da menor distancia.
        /// </summary>
        /// <param name="minDistance">valor menor distancia</param>
        /// <returns>Valor de D</returns>
        public int CalculOfD(int minDistance)
        {
            int D = 0;

            if (minDistance <= 5)
            {
                D = 100;
            }
            else if (minDistance <= 10 )
            {
                D = 75;
            }
            else if (minDistance <= 15)
            {
                D = 50;
            }
            else if (minDistance <= 25)
            {
                D = 25;
            }

            return D;
        }

        /// <summary>
        /// Esse metodo calculo a distancia
        /// do caminho minimo.
        /// </summary>
        /// <param name="start"> Ponto de ida</param>
        /// <param name="target">Ponto de chegada</param>
        /// <returns>Menor distancia</returns>
        public int MinimumDistance(string start, string target)
        {
            if (start == target) return 0;

            Node StartNode = new Node();
            StartNode.GetNodeByName(start);
            PathGraph path = new PathGraph(start);
            int minDistance = Int32.MaxValue;
            PathFinder(StartNode, target, path, ref minDistance);

            return minDistance;
        }

        /// <summary>
        /// Metodo de busca do menor caminho.
        /// </summary>
        /// <param name="startNode">Node de ida</param>
        /// <param name="target">Ponto de chegada</param>
        /// <param name="path">Pontos de Caminhos</param>
        /// <param name="minDistance">Distancia minima achada</param>
        public void PathFinder(Node startNode, string target, PathGraph path, ref int minDistance)
        {
            // Para cada vizinho de um ponto de ida 
            foreach (var neighbor in startNode.neighborList)
            {
                //Calcule soma da distancia atual ate ao vizinho
                int DistanceToCompare = path.TotalDistance + neighbor.Distance;

                // Se a soma e' maior do que distancia menor despreza o caminho.
                if (DistanceToCompare >= minDistance) continue;

                // Se ja passou pelo este vizinho, despreza o caminho.
                if (path.Nodes.Split(',').Contains(neighbor.Name)) continue;


                /* Se este vizinho e' o ponto de chegada final, 
                 * guarda o valor da distancia
                 */
                if (neighbor.Name.Equals(target))
                {
                    minDistance = DistanceToCompare;
                    continue;
                }


                Node neighborNode = new Node();
                neighborNode.GetNodeByName(neighbor.Name);

                /* Se o vizinho e' uma folha ("A" ou "F") 
                 Checa se nao e' o ponto de chegada final, despreza o caminho.
                 */
                if (neighborNode.IsLeaf)
                {
                    if (!neighborNode.Name.Equals(target)) continue;
                }

                /* Continue a busca
                 */
                PathGraph newPath = new PathGraph(path.Nodes, path.TotalDistance);
                newPath.TotalDistance += neighbor.Distance;
                newPath.Nodes += "," + neighbor.Name;

                PathFinder(neighborNode, target, newPath, ref minDistance);
            }
        }

        /// <summary>
        /// Esse metodo faz o calcul do N
        /// </summary>
        /// <param name="nivelVaga">Nivel da vaga</param>
        /// <param name="nivelPessoa">Nivel do candidato</param>
        /// <returns>Retorne N</returns>
        public int CalculOfN (int nivelVaga, int nivelPessoa)
        {
            int result = 0;
            int differenceNivel = nivelVaga - nivelPessoa;

            if (differenceNivel < 0)
            {
                differenceNivel = differenceNivel * (-1);
            }

            result = 100 - (25 * differenceNivel);

            return result;
        }

        /// <summary>
        /// Esse metodo calcula o Score.
        /// </summary>
        /// <param name="start">Ponto de Ida</param>
        /// <param name="target">Ponto de chegada</param>
        /// <param name="nivelVaga">nivel da vaga</param>
        /// <param name="nivelPessoa">nivel do Candidato</param>
        /// <returns></returns>
        public decimal CalculOfScore(string start, string target, int nivelVaga, int nivelPessoa)
        {
            int N = CalculOfN(nivelVaga, nivelPessoa);
            int minDistance = MinimumDistance(start, target);
            int D = CalculOfD(minDistance);
            decimal result = (decimal)(N + D) / 2;
            return result;

        }
    }
}
