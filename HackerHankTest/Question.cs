using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerHankTest
{
    public class Question
    {
        public static int BusyBeaver(List<List<int>> forest)
        {

            var logsAmount = 0;
            var maxRow = forest.Count;
            var maxColumn = forest[0].Count;
            var continueHunt = true;

            Console.WriteLine(maxColumn);
            Console.WriteLine(maxRow);

            ShowMatrix(forest, maxRow, maxColumn);

            //Set the center of the matrix
            var matrixCenterRow = maxRow / 2;
            var matrixCenterColumn = maxColumn / 2;

            if (forest[matrixCenterRow][matrixCenterColumn] < forest[matrixCenterRow - 1][matrixCenterColumn])
            {
                matrixCenterRow--;
            }

            if (forest[matrixCenterRow][matrixCenterColumn] < forest[matrixCenterRow][matrixCenterColumn - 1])
            {
                matrixCenterColumn--;
            }

            var matrixCurrentRow = matrixCenterRow;
            var matrixCurrentColumn = matrixCenterColumn;
            logsAmount = forest[matrixCurrentRow][matrixCurrentColumn];
            forest[matrixCurrentRow][matrixCurrentColumn] = 0;

            while (continueHunt)
            {
                var position = ReturnPosition(forest, matrixCurrentRow, matrixCurrentColumn, maxRow, maxColumn);

                if (position.valueUp > position.valueDown && position.valueUp > position.valueLeft && position.valueUp > position.valueRight)
                {
                    matrixCurrentRow = position.indexUp;
                }
                else if (position.valueDown > position.valueUp && position.valueDown > position.valueLeft && position.valueDown > position.valueRight)
                {
                    matrixCurrentRow = position.indexDown;
                }
                else if (position.valueLeft > position.valueRight && position.valueLeft > position.valueUp && position.valueLeft > position.valueDown)
                {
                    matrixCurrentColumn = position.indexLeft;
                }
                else if (position.valueRight > position.valueLeft && position.valueRight > position.valueUp && position.valueRight > position.valueDown)
                {
                    matrixCurrentColumn = position.indexRight;
                }

                logsAmount += forest[matrixCurrentRow][matrixCurrentColumn];
                forest[matrixCurrentRow][matrixCurrentColumn] = 0;

                var p = ReturnPosition(forest, matrixCurrentRow, matrixCurrentColumn, maxRow, maxColumn);

                if (p.valueUp == 0 && p.valueDown == 0 && p.valueLeft == 0 && p.valueRight == 0)
                {
                    continueHunt = false;
                }
            }

            Console.WriteLine(logsAmount);
            return logsAmount;
        }

        private class Position
        {
            public int valueUp { get; set; }
            public int indexUp { get; set; }
            public int valueDown { get; set; }
            public int indexDown { get; set; }
            public int valueLeft { get; set; }
            public int indexLeft { get; set; }
            public int valueRight { get; set; }
            public int indexRight { get; set; }

        }

        private static Position ReturnPosition(List<List<int>> forest, int currentRow, int currentColumn, int maxRow, int maxColumn)
        {
            var position = new Position();

            //Up
            if (currentRow - 1 >= 0)
            {
                position.indexUp = currentRow - 1;
                position.valueUp = forest[position.indexUp][currentColumn];
            }
            else
            {
                position.indexUp = currentRow;
                position.valueUp = 0;
            }

            //Down
            if (currentRow + 1 <= maxRow - 1)
            {
                position.indexDown = currentRow + 1;
                position.valueDown = forest[position.indexDown][currentColumn];
            }
            else
            {
                position.indexDown = currentRow;
                position.valueDown = 0;
            }

            //Left
            if (currentColumn - 1 >= 0)
            {
                position.indexLeft = currentColumn - 1;
                position.valueLeft = forest[currentRow][position.indexLeft];
            }
            else
            {
                position.indexLeft = currentColumn;
                position.valueLeft = 0;
            }

            //Right
            if (currentColumn + 1 <= maxColumn - 1)
            {
                position.indexRight = currentColumn + 1;
                position.valueRight = forest[currentRow][position.indexRight];
            }
            else
            {
                position.indexRight = currentColumn;
                position.valueRight = 0;
            }

            return position;
        }

        private static void ShowMatrix(List<List<int>> forest, int maxRow, int maxColumn)
        {
            var matrix = "";
            for (int r = 0; r < maxRow; r++)
            {
                for (int c = 0; c < maxColumn; c++)
                {
                    matrix += forest[r][c];
                }
                matrix = $"{matrix}{Environment.NewLine}"; ;
            }
            Console.WriteLine(matrix);
        }
    }
}
