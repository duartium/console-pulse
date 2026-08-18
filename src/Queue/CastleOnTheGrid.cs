var grid = new List<string>
{
    ".X.",
    ".X.",
    "...",
};

int result = Result.minimumMoves(grid, 0, 0, 0, 2);

Console.WriteLine($"minimumMoves: {result}"); // expected: 3

class Result
{

    /*
     * Complete the 'minimumMoves' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts following parameters:
     *  1. STRING_ARRAY grid
     *  2. INTEGER startX
     *  3. INTEGER startY
     *  4. INTEGER goalX
     *  5. INTEGER goalY
     */

    public static int minimumMoves(
        List<string> grid,
        int startX,
        int startY,
        int goalX,
        int goalY)
    {
        int n = grid.Count;
        int m = grid[0].Length;
        var visited = new bool[n, m];
        var queue = new Queue<(int x, int y, int moves)>();

        queue.Enqueue((startX, startY, 0));

        int[] dx = { -1, 1, 0, 0 };
        int[] dy = { 0, 0, -1, 1 };

        while(queue.Count > 0)
        {
            var (x, y, moves) = queue.Dequeue();

            if(x == goalX && y == goalY)
                return moves;

            for (int dir = 0; dir < 4; dir++)
            {
                int newX = x;
                int newY = y;

                while (true)
                {
                    int nextX = newX + dx[dir];
                    int nextY = newY + dy[dir];

                    if (nextX < 0 || nextX >= n || nextY < 0 || nextY >= m || grid[nextX][nextY] == 'X')
                    {
                        break;
                    }

                    newX = nextX;
                    newY = nextY;

                    if (!visited[newX, newY])
                    {
                        visited[newX, newY] = true;
                        queue.Enqueue((newX, newY, moves + 1));
                    }
                }
            }
        }

        return -1;
    }

}
