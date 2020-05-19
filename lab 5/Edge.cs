namespace lab_5
{
    class Edge
    {
        #region Properties
        public string Name { get; set; }
        public Vertice FirstVertice { get; set; }
        public Vertice SecondVertice { get; set; }
        #endregion

        #region Constructors
        public Edge(Vertice firstVertice, Vertice secondVertice, string name)
        {
            FirstVertice = firstVertice;
            SecondVertice = secondVertice;
            Name = name;
        }
        #endregion
    }
}
