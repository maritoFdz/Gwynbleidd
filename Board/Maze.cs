namespace Gwynbleidd.Board
{
    public class Maze
    {
        public bool[,] Cells { get; private set; }

        public Maze(int width, int height)
        {
            if (width < 1 || height < 1)
                throw new ArgumentException("Width and height must be at least 1.");
            Cells = new bool[height, width];
        }

        public void PrintBoard()
        {
            for (int i = 0; i < Cells.GetLength(0); i++)
            {
                for (int j = 0; j < Cells.GetLength(1); j++)
                    Console.Write(Cells[i, j] ? "*" : "+");
                Console.WriteLine();
            }
        }
    }
}
