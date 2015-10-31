namespace _14.Labyrinth
{
    public class Cell
    {
        public int Row { set; get; }
        public int Col { set; get; }
        public int Distance { set; get; }

        public Cell(int x, int y, int distance)
        {
            this.Row = x;
            this.Col = y;
            this.Distance = distance;
        }
    }
}
