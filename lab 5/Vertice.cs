using System.Collections.Generic;

namespace lab_5
{
    class Vertice
    {
        #region Properties
        public List<Edge> AdjacentEdges { get; set; }
        public string Name { get; set; }
        private static int number = 0;
        #endregion

        #region Constructors
        public Vertice()
        {
            AdjacentEdges = new List<Edge>();
            Name = "Vertice " + number.ToString();
            number++;
        }
        #endregion

        #region Methods
        public int Degree()
        {
            int degree = 0;
            for ( int i = 0; i < AdjacentEdges.Count; i++ )
            {
                if ( AdjacentEdges[i].FirstVertice == AdjacentEdges[i].SecondVertice ) degree += 2;
                else degree++;
            }
            return degree;
        }
        public int DoubleDegree()
        {
            int doubleDegree = 0;
            List<Vertice> Checked = new List<Vertice>();
            for ( int i = 0; i < AdjacentEdges.Count; i++ )
            {
                if ( Checked.Contains(AdjacentEdges[i].SecondVertice) || AdjacentEdges[i].FirstVertice == AdjacentEdges[i].SecondVertice ) continue;
                doubleDegree += AdjacentEdges[i].SecondVertice.Degree();
                Checked.Add(AdjacentEdges[i].SecondVertice);
            }
            return doubleDegree;
        }
        #endregion
    }
}
