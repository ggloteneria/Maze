using System;
using System.Collections.Generic;
using System.Linq;

namespace Labirint {
    public class MazeForEllerGenerator {
        static Random randomizer = new Random();
        static int size;
        static int[][] maze;

        static Cel[] makeSet(Cel[] row) {
            for (int index = 0; index < row.Length;) {
                Cel cell = row[index++];
                if (cell.set == null) {
                    var list = new List<Cel>();
                    list.Add(cell);
                    cell.set = list;
                }
            }

            return row;
        }

        static Cel[] makeRightWalls(Cel[] row) {
            for (int i = 1; i < row.Length; i++) {
                if (isContainsInList(row[i - 1].set, row[i])) {
                    row[i - 1].right = true;
                    continue;
                }

                if (randomizer.Next(2) == 1)
                    row[i - 1].right = true;
                else
                    row = merge(row, i);
            }

            return row;
        }

        static Cel[] merge(Cel[] row, int i) {
            //utility function
            List<Cel> currentList = row[i - 1].set;
            List<Cel> nextList = row[i].set;
            foreach (Cel j in nextList) {
                currentList.Add(j);
                j.set = currentList;
            }

            return row;
        }

        static bool isContainsInList(List<Cel> set, Cel cell) {
            //utility function
            foreach (Cel i in set) {
                if (i == cell)
                    return true;
            }

            return false;
        }

        static bool isNotDone(List<Cel> set) {
            //utility function
            return set.Aggregate(true, (current, x) => current && x.down);
        }

        static Cel[] makeDown(Cel[] row) {
            for (int i = 0; i < row.Length; i++) {
                foreach (var x in row[i].set) {
                    x.down = true;
                }

                while (isNotDone(row[i].set)) {
                    do {
                        row[i].set[randomizer.Next(row[i].set.Count)].down = false;
                    } while (randomizer.Next(2) == 1);
                }
            }

            return row;
        }

        public static void driver(Maze mazeToModify) {
            size = mazeToModify.cells.GetUpperBound(0) / 2;

            maze = new int[2 * size + 1][];
            for (int i = 0; i < maze.Length; i++) {
                maze[i] = new int[2 * size + 1];
            }

            Cel[] cur = new Cel[size];
            for (int i = 0; i < size; i++) {
                cur[i] = new Cel(0, i);
            }

            for (int i = 2; i <= 2 * size; i++) {
                for (int j = 2; j <= 2 * size; j++) {
                    maze[i][j] = 0;
                }
            }

            for (int i = 0; i < size; i++) {
                cur = makeSet(cur);
                cur = makeRightWalls(cur);
                cur = makeDown(cur);
                if (i == size - 1)
                    cur = end(cur);
                printMaze(cur, i);
                if (i != size - 1)
                    cur = genNextRow(cur);
            }

            //Creating upper and left boundary
            for (int i = 0; i <= 2 * size; i++) {
                maze[i][0] = maze[0][i] = maze[i][2 * size] = maze[2 * size][i] = 1;
            }

            for (int i = 2; i <= 2 * size; i += 2) {
                for (int j = 2; j <= 2 * size; j += 2) {
                    maze[i][j] = 1;
                }
            }

            for (int i = 0; i < 2 * size + 1; i++) {
                for (int j = 0; j < 2 * size + 1; j++) {
                    bool isCell = maze[i][j] == 0;
                    if (isCell) {
                        mazeToModify.cells[j, i].IsCell = true;
                        mazeToModify.cells[j, i].IsVisited = true;
                    }
                    else {
                        mazeToModify.cells[j, i].IsCell = false;
                        mazeToModify.cells[j, i].IsVisited = false;
                    }
                }
            }
        }

        static Cel[] end(Cel[] row) {
            for (int i = 1; i < row.Length; i++) {
                if (findPos(row[i - 1].set, row[i]) == -1) {
                    row[i - 1].right = false;
                    row = merge(row, i);
                }
            }

            return row;
        }

        static int findPos(List<Cel> set, Cel x) {
            var tmpArray = set.ToArray();
            for (int i = 0; i < tmpArray.Length; i++)
                if (tmpArray[i] == x)
                    return i;
            return -1;
        }

        static Cel[] genNextRow(Cel[] pre) {
            foreach (var item in pre) {
                item.right = false;
                item.x++;
                if (!item.down) {
                    continue;
                }

                item.set.RemoveAt(findPos(item.set, item));
                item.set = null;
                item.down = false;
            }

            return pre;
        }

        static void printMaze(Cel[] row, int rowPos) {
            rowPos = 2 * rowPos + 1;
            for (int i = 0; i < row.Length; i++) {
                if (row[i].right)
                    maze[rowPos][2 * i + 2] = 1;
                if (row[i].down)
                    maze[rowPos + 1][2 * i + 1] = 1;
            }
        }
    }

    public class Cel {
        public bool right, down;
        public List<Cel> set;
        public int x, y;

        public Cel(int a, int b) {
            x = a;
            y = b;
            right = false;
            down = true;
            set = null;
        }
    }
}