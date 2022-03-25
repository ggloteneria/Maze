using System;
using System.Collections;
using System.Collections.Generic;

namespace Labirint {
    /*
     * Класс лабиринта
     */

    [Serializable]
    public class Maze {
        public Theme Theme { get; set; }
        public readonly Cell[,] cells;
        public int width;
        public int height;
        public Stack<Cell> path = new Stack<Cell>();
        public List<Cell> solve = new List<Cell>();
        public List<Cell> visited = new List<Cell>();
        public List<Cell> neighbours = new List<Cell>();
        public Cell start;
        public Cell finish;

        /*
         * Конструктор для создания шаблона без входа и выхода
         */
        public Maze(int width, int height) {
            this.width = width;
            this.height = height;
            cells = new Cell[width, height];
            for (var i = 0; i < width; i++)
            for (var j = 0; j < height; j++)
                // Все клетки на границах -- стены
                if (i != 0 && j != 0 && i < this.width - 1 && j < this.height - 1) {
                    cells[i, j] = new Cell(i, j); //то это клетка (по умолчанию)
                }
                else {

                    cells[i, j] = new Cell(i, j, false, false);
                }

            path.Push(start);
            cells[start.X, start.Y] = start;
        }

        /*
         * Конструктор для создания шаблона со входом и выходом
         */
        public Maze(int width, int height, int sx, int sy, int fx, int fy) {
            start = new Cell(sx, sy, true);
            finish = new Cell(fx, fy, true);
            //finish = new Cell(0, 0, true, true);

            this.width = width;
            this.height = height;
            cells = new Cell[width, height];
            for (var i = 0; i < width; i++)
            for (var j = 0; j < height; j++)
                //если ячейка нечетная по х и по у и не выходит за пределы лабиринта
                if (i % 2 != 0 && j % 2 != 0 && i < this.width - 1 && j < this.height - 1) {
                    cells[i, j] = new Cell(i, j); //то это клетка (по умолчанию)
                }
                else {

                    cells[i, j] = new Cell(i, j, false, false);
                }

            //_path.Push(start);
            //_cells[start.X, start.Y] = start;
            path.Push(AdjustBorderCell(start));
            cells[start.X, start.Y] = AdjustBorderCell(start);

        }

        /*
         * Получение клетки для возможных входа и выхода
         */
        public List<Cell> getBorderCells() {
            List<Cell> borderCells = new List<Cell>();

            for (int i = 0; i < width; i++) {
                for (int j = 0; j < height; j++) {
                    if (!cells[i, j].IsCell & !CheckCorner(cells[i, j]) &
                        (i % 2 != 0 || j % 2 != 0))
                        borderCells.Add(cells[i, j]);
                }
            }

            return borderCells;
        }

        /*
         * Проверить находится ли клетка на углу
         */
        public bool CheckCorner(Cell c) {
            if (c.X == 0 & (c.Y == 0 || c.Y == height - 1))
                return true;
            return c.X == width - 1 & (c.Y == 0 || c.Y == height - 1);
        }

        /*
         * Алгоритм правой руки
         */
        public void SolveRightHandMaze() {
            var curFinish = AdjustBorderCell(finish);
            bool flag = false; //флаг достижения финиша
            foreach (var c in cells) {
                if (cells[c.X, c.Y].IsCell) {
                    cells[c.X, c.Y].IsVisited = false;
                }
            }

            path.Clear();
            path.Push(start);

            while (path.Count != 0) //пока в стеке есть клетки ищем соседей и строим путь
            {
                if (path.Peek().X == curFinish.X && path.Peek().Y == curFinish.Y) {
                    flag = true;
                }

                if (!flag) {
                    neighbours.Clear();
                    GetNeighboursSolve(path.Peek());
                    if (neighbours.Count != 0) {
                        var nextCell = ChooseNeighbour(neighbours, true);
                        nextCell.IsVisited = true; //делаем текущую клетку посещенной
                        cells[nextCell.X, nextCell.Y].IsVisited = true; //и в общем массиве
                        path.Push(nextCell); //затем добавляем её в стек
                        visited.Add(path.Peek());
                    }
                    else {
                        path.Pop();
                    }
                }
                else {
                    solve.Add(path.Peek());
                    path.Pop();
                }
            }
        }


        /*
         * Волновой Алгоритм
         */
        public void SolveWaveMaze() {
            var curFinish = AdjustBorderCell(finish);
            bool flag = false; //флаг достижения финиша
            foreach (var c in cells) {
                if (cells[c.X, c.Y].IsCell) {
                    cells[c.X, c.Y].IsVisited = false;
                }
            }

            path.Clear();
            path.Push(start);

            while (path.Count != 0) //пока в стеке есть клетки ищем соседей и строим путь
            {
                if (path.Peek().X == curFinish.X && path.Peek().Y == curFinish.Y) {
                    flag = true;
                }

                if (!flag) {
                    neighbours.Clear();
                    GetNeighboursSolve(path.Peek());
                    if (neighbours.Count != 0) {
                        var nextCell = ChooseNeighbour(neighbours, true);
                        nextCell.IsVisited = true; //делаем текущую клетку посещенной
                        cells[nextCell.X, nextCell.Y].IsVisited = true; //и в общем массиве
                        path.Push(nextCell); //затем добавляем её в стек
                        visited.Add(path.Peek());
                    }
                    else {
                        path.Pop();
                    }
                }
                else {
                    solve.Add(path.Peek());
                    path.Pop();
                }
            }
        }

        /*
         * Скорректировать координаты входа и выхода для алгоритмов
         */
        private Cell AdjustBorderCell(Cell c) {
            if (c.X == 0)
                c.X++;
            else if (c.Y == 0)
                c.Y++;
            else if (c.X == width - 1)
                c.X--;
            else if (c.Y == height - 1)
                c.Y--;
            return c;
        }

        /*
         * Генерация лабиринта алгоритмом Эллера
         */
        public void CreateEllerMaze() {
            MazeForEllerGenerator.driver(this);
        }
        
        /*
         * Генерация лабиринта алгоритмом Прима
         */
        public void CreatePrimMaze() {
            cells[start.X, start.Y] = AdjustBorderCell(start);
            Cell firstCell = AdjustBorderCell(start);
            cells[firstCell.X, firstCell.Y].IsVisited = true;
            firstCell.IsVisited = true;
            while (path.Count != 0) {
                neighbours.Clear();
                GetNeighbours(path.Peek());
                if (neighbours.Count != 0) {
                    var nextCell = ChooseNeighbour(neighbours, false);
                    RemoveWall(path.Peek(), nextCell);
                    nextCell.IsVisited = true;
                    cells[nextCell.X, nextCell.Y].IsVisited = true;
                    path.Push(nextCell);

                }
                else {
                    path.Pop();
                }
            }
        }

        /*
         * Получение соседей текущей клетки для алгоритмов генерации
         */
        private void GetNeighbours(Cell localCell) {

            int x = localCell.X;
            int y = localCell.Y;
            const int DISTANCE = 2;
            Cell[] possibleNeighbours =
            {
                new Cell(x, y - DISTANCE), // Up
                new Cell(x + DISTANCE, y), // Right
                new Cell(x, y + DISTANCE), // Down
                new Cell(x - DISTANCE, y), // Left
            };
            for (int i = 0; i < 4; i++) // Проверяем все 4 направления
            {
                var curNeighbour = possibleNeighbours[i];
                if (curNeighbour.X <= 0 || curNeighbour.X >= width ||
                    curNeighbour.Y <= 0 || curNeighbour.Y >= height) {
                    continue;
                }

                if (cells[curNeighbour.X, curNeighbour.Y].IsCell &&
                    !cells[curNeighbour.X, curNeighbour.Y].IsVisited) {
                    neighbours.Add(curNeighbour);
                }
            }

        }

        /*
         * Получение соседей текущей клетки для алгоритма поиска пути
         */
        private void GetNeighboursSolve(Cell localCell) {

            int x = localCell.X;
            int y = localCell.Y;
            const int DISTANCE = 1;
            Cell[] possibleNeighbours =
            {
                new Cell(x, y - DISTANCE), // Up
                new Cell(x + DISTANCE, y), // Right
                new Cell(x, y + DISTANCE), // Down
                new Cell(x - DISTANCE, y), // Left
            };
            for (int i = 0; i < 4; i++) // Проверяем все 4 направления
            {
                var curNeighbour = possibleNeighbours[i];
                if (curNeighbour.X <= 0 ||
                    curNeighbour.X >= width ||
                    curNeighbour.Y <= 0 ||
                    curNeighbour.Y >= height) {
                    continue;
                }

                // Если сосед не выходит за стенки лабиринта
                if (cells[curNeighbour.X, curNeighbour.Y].IsCell &&
                    !cells[curNeighbour.X, curNeighbour.Y].IsVisited) {
                    // А также является клеткой и непосещен
                    neighbours.Add(curNeighbour);
                } // добавляем соседа в Лист соседей
            }

        }

        private static Random rndGo = new Random(1);
        private static Random rndGen = new Random();
        /*
         * Выбор правого соседа
         */
        private Cell ChooseNeighbour(
            List<Cell> localNeighbours,
            bool go) {
            var rnd = go ? rndGo : rndGen;
            int r = rnd.Next(localNeighbours.Count);
            return localNeighbours[r];

        }

        /*
         * Удаление стены
         */
        private void RemoveWall(Cell first, Cell second) {
            int xDiff = second.X - first.X;
            int yDiff = second.Y - first.Y;
            int addX =
                xDiff != 0 ? xDiff / Math.Abs(xDiff) : 0; // Узнаем направление удаления стены
            int addY = yDiff != 0 ? yDiff / Math.Abs(yDiff) : 0;

            // Координаты удаленной стены
            cells[first.X + addX, first.Y + addY].IsCell = true; //обращаем стену в клетку
            cells[first.X + addX, first.Y + addY].IsVisited = true; //и делаем ее посещенной
            second.IsVisited = true; //делаем клетку посещенной
            cells[second.X, second.Y] = second;

        }
    }
}