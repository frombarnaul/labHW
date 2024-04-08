namespace lab
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] labyrinth1 = new int[,]
            {
            {1, 1, 1, 1, 1, 1, 1 },
            {1, 0, 0, 0, 0, 0, 1 },
            {1, 0, 1, 1, 1, 0, 1 },
            {0, 0, 0, 0, 1, 0, 0 },
            {1, 1, 0, 0, 1, 1, 1 },
            {1, 1, 1, 0, 1, 0, 1 },
            {1, 1, 1, 0, 1, 1, 1 }
            };
            int exits = HasExit(5, 5, labyrinth1);
            Console.WriteLine("Total exits: " + exits);

            static int HasExit(int startI, int startJ, int[,] labyrinth)
            {
                int rows = labyrinth.GetLength(0);
                int cols = labyrinth.GetLength(1);

                int[] dr = { -1, 0, 1, 0 };
                int[] dc = { 0, 1, 0, -1 };

                int exits = 0;

                void DFS(int r, int c)
                {
                    if (r < 0 || c < 0 || r >= rows || c >= cols || labyrinth[r, c] == 1)
                        return;

                    if (r == 0 || c == 0 || r == rows - 1 || c == cols - 1)
                    {
                        exits++;
                        return;
                    }

                    labyrinth[r, c] = 1;

                    for (int i = 0; i < 4; i++)
                    {
                        DFS(r + dr[i], c + dc[i]);
                    }
                }

                DFS(startI, startJ);

                return exits;
            }
        }
    }
}
