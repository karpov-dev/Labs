using System.Collections.Generic;

namespace lab_5
{
    class Graph
    {
        #region Properties
        public List<Edge> Edges { get; set; }
        public List<Vertice> Vertices { get; set; }
        #endregion

        #region Constructors
        public Graph()
        {
            Edges = new List<Edge>();
            Vertices = new List<Vertice>();
        }
        #endregion

        #region Methods
        public bool IsBipartite()
        {
            List<Vertice> firstGroup = new List<Vertice>(),
                          secondGroup = new List<Vertice>();
            Vertice justChecked = null;

            if ( Vertices.Count == 2 ) //проверяю или соеденены вершины одним ребром
            {
                if ( Vertices[0].AdjacentEdges.Count != 1 || Vertices[1].AdjacentEdges.Count != 1 ) return false;
                else return true;
            }

            foreach ( Vertice vertice in Vertices ) // ищу вершину, у которой количество рёбер больше 1, для того, чтобы с неё начать
            {
                if ( vertice.AdjacentEdges.Count > 1 )
                {
                    justChecked = vertice;
                    break;
                }
            }

            bool isfirstGroup = true;
            firstGroup.Add(justChecked);
            while ( true )
            {
                if ( secondGroup.Count + firstGroup.Count == Vertices.Count - WithOneEdge() ) break;
                if ( isfirstGroup )
                {
                    foreach ( Edge edge in justChecked.AdjacentEdges )
                    {
                        if ( edge.SecondVertice == edge.FirstVertice ) return false; //проверка на петлю
                        if ( !firstGroup.Contains(edge.SecondVertice) && !secondGroup.Contains(edge.SecondVertice) )
                        {
                            if ( edge.SecondVertice.AdjacentEdges.Count > 1 ) //исключаю тупик
                            {
                                bool isContinue = true;
                                foreach ( Edge edge1 in edge.SecondVertice.AdjacentEdges )
                                {
                                    if ( secondGroup.Contains(edge1.SecondVertice) ) //проверяю на соединение с другой группой
                                    {
                                        isContinue = false;
                                        break;
                                    }
                                }
                                if ( !isContinue ) continue;
                                isfirstGroup = false;
                                secondGroup.Add(edge.SecondVertice);
                                justChecked = edge.SecondVertice;
                                break;
                            }
                            if ( secondGroup.Count + firstGroup.Count == Vertices.Count - 1 ) return true;
                        }
                    }
                    if ( isfirstGroup ) return false;
                }
                else
                {
                    foreach ( Edge edge in justChecked.AdjacentEdges )
                    {
                        //по аналогии, только для другой группы
                        if ( edge.SecondVertice == edge.FirstVertice ) return false;
                        if ( !firstGroup.Contains(edge.SecondVertice) && !secondGroup.Contains(edge.SecondVertice) )
                        {
                            if ( edge.SecondVertice.AdjacentEdges.Count > 1 )
                            {
                                bool isContinue = true;
                                foreach ( Edge edge1 in edge.SecondVertice.AdjacentEdges )
                                {
                                    if ( firstGroup.Contains(edge1.SecondVertice) )
                                    {
                                        isContinue = false;
                                        break;
                                    }
                                }
                                if ( !isContinue ) continue;
                                isfirstGroup = true;
                                firstGroup.Add(edge.SecondVertice);
                                justChecked = edge.SecondVertice;
                                break;
                            }
                            if ( secondGroup.Count + firstGroup.Count == Vertices.Count - 1 ) return true;
                        }
                    }
                    if ( !isfirstGroup ) return false;
                }
            }
            return true;
        }
        public bool IsCycled()
        {
            //прохожу по вершинам, записываю  в checked имена ребёр которые прошел
            //для каждой следующей вершины ищу лучший переход (та вершина, у которой больше всего рёбер) 
            //перехожу в лучший переход до тех пор, пока не закончатся вершины, либо пока не приду в начало 
            Vertice start,
                    current, bestVariant = null;
            List<string> Checked;
            string toCheck = null;
            foreach ( Vertice vertice in Vertices )
            {
                start = vertice;
                current = vertice;
                Checked = new List<string>();
                if ( start.AdjacentEdges.Count == 1 ) continue;
                while ( true )
                {
                    foreach ( Edge edge in current.AdjacentEdges )
                    {
                        if ( Checked.Contains(edge.Name) ) continue;
                        if ( bestVariant == null )
                        {
                            bestVariant = edge.SecondVertice;
                            toCheck = edge.Name;
                        }
                        if ( bestVariant.AdjacentEdges.Count < edge.SecondVertice.AdjacentEdges.Count )
                        {
                            bestVariant = edge.SecondVertice;
                            toCheck = edge.Name;
                        }
                        if ( edge.SecondVertice == start && current != start ) return true;
                    }
                    if ( bestVariant == null ) break;
                    current = bestVariant;
                    Checked.Add(toCheck);
                    toCheck = null;
                    bestVariant = null;
                }

            }
            return false;
        }
        private int WithOneEdge()
        {
            int amount = 0;
            foreach ( Vertice vertice in Vertices )
            {
                if ( vertice.Degree() == 1 ) amount++;
            }
            return amount;
        }
        #endregion
    }
}
