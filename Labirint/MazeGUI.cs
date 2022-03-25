using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Labirint {
    /*
     * Класс для отрисовки лабиринта
     */
    internal static class MazeGui {
        public static Bitmap DrawMaze(
            Bitmap inBm,
            int cellWidth,
            int cellHeight,
            Maze maze,
            int oddW,
            int oddH,
            Theme theme) {
            inBm.Dispose();
            maze.Theme = theme;
            var bm = new Bitmap(
                cellWidth * maze.width, cellHeight * maze.height,
                System.Drawing.Imaging.PixelFormat.Format16bppRgb555);

            Brush blackBrush = new SolidBrush(maze.Theme.WallColor);

            using (var gr = Graphics.FromImage(bm)) {

                gr.SmoothingMode = SmoothingMode.AntiAlias;
                
                int totalWidth = cellWidth * maze.cells.GetUpperBound(0);
                int totalHeight = cellHeight * maze.cells.GetUpperBound(1);

                var imgFromFile = Image.FromFile(maze.Theme.BackgroundImage);
                var imageBrush = new TextureBrush(Utils.ResizeImage(
                    imgFromFile, totalWidth, totalHeight));

                gr.FillRectangle(imageBrush, new Rectangle(
                    new Point(0, 0),
                    new Size(totalWidth, totalHeight)));
                for (var i = 0; i < maze.cells.GetUpperBound(0) + oddW; i++) {
                    for (var j = 0; j < maze.cells.GetUpperBound(1) + oddH; j++) {
                        var point = new Point(i * cellWidth, j * cellWidth);
                        var size = new Size(cellWidth, cellWidth);
                        var rec = new Rectangle(point, size);
                        if (!maze.cells[i, j].IsCell) {
                            gr.FillRectangle(blackBrush, rec);
                        }
                    }
                }

                if (maze.start.X != 0 || maze.start.Y != 0) {
                    gr.FillRectangle(new SolidBrush(Color.Green),
                        new Rectangle(new Point(maze.start.X * cellWidth, maze.start.Y * cellWidth),
                            new Size(cellWidth, cellWidth)));

                    var head = (Bitmap)Image.FromFile(maze.Theme.HeroImage);
                    gr.DrawImage(head,
                        new RectangleF(
                            new Point(maze.start.X * cellWidth, maze.start.Y * cellWidth),
                            new SizeF(cellWidth, cellHeight)));
                }

                if (maze.finish.X != 0 || maze.finish.Y != 0) {
                    gr.FillRectangle(new SolidBrush(Color.Red),
                        new Rectangle(
                            new Point(maze.finish.X * cellWidth, maze.finish.Y * cellWidth),
                            new Size(cellWidth, cellWidth)));
                }
            }

            return bm;

        }

        /*
         * Отрисовка пути для волнового алгоритма
         */
        public static Bitmap DrawWaveSolve(Bitmap inBm, Maze inMaze, int cellWid) {
            using (var gr = Graphics.FromImage(inBm)) {
                gr.SmoothingMode = SmoothingMode.AntiAlias;

                foreach (var c in inMaze.solve) {
                    var point = new Point(c.X * cellWid, c.Y * cellWid);
                    var size = new Size(cellWid, cellWid);

                    var tail = (Bitmap)Image.FromFile(inMaze.Theme.TailImage);
                    gr.DrawImage(tail, new RectangleF(point, size));
                }

                gr.FillRectangle(new SolidBrush(Color.Green), //заливаем старт зеленым
                    new Rectangle(new Point(inMaze.start.X * cellWid, inMaze.start.Y * cellWid),
                        new Size(cellWid, cellWid)));
                gr.FillRectangle(new SolidBrush(Color.Red), //а финиш красным
                    new Rectangle(new Point(inMaze.finish.X * cellWid, inMaze.finish.Y * cellWid),
                        new Size(cellWid, cellWid)));
            }

            return inBm; //отображаем картинку
        }


        /*
         * Отрисовка пути для агоритма правой руки (динамическая)
         */
        public static Bitmap DrawDynamic(Bitmap inBm, Maze inMaze, int cellWid, int cellHgt,
            Point p, int i, int j) {
            using (var gr = Graphics.FromImage(inBm)) {
                gr.SmoothingMode = SmoothingMode.AntiAlias;

                p.X = inMaze.visited[i].X;
                p.Y = inMaze.visited[i].Y;
                var point = new Point(p.X * cellWid, p.Y * cellWid);
                var size = new Size(cellWid, cellWid);


                var tail = (Bitmap)Image.FromFile(inMaze.Theme.TailImage);
                var filler = (Bitmap)Image.FromFile(inMaze.Theme.BackgroundImage);
                
                gr.DrawImage(filler, new RectangleF(point, size));
                gr.DrawImage(tail, new RectangleF(point, size));
                
                p.X = inMaze.visited[i + 1].X;
                p.Y = inMaze.visited[i + 1].Y;

                var head = (Bitmap)Image.FromFile(inMaze.Theme.HeroImage);
                gr.DrawImage(head,
                    new RectangleF(new Point(p.X * cellWid, p.Y * cellWid),
                        new SizeF(cellWid, cellHgt)));

                gr.FillRectangle(new SolidBrush(Color.Green), //заливаем старт зеленым
                    new Rectangle(new Point(inMaze.start.X * cellWid, inMaze.start.Y * cellWid),
                        new Size(cellWid, cellWid)));
                gr.FillRectangle(new SolidBrush(Color.Red), //а финиш красным
                    new Rectangle(new Point(inMaze.finish.X * cellWid, inMaze.finish.Y * cellWid),
                        new Size(cellWid, cellWid)));
            }

            return inBm;
        }

        public static void normalizeVisited(Maze inMaze) {
            for (int i = 1; i < inMaze.visited.Count; i++) {
                if (!AreNeighbours(inMaze.visited[i - 1], inMaze.visited[i])) {
                    for (int j = i; j >= 0; j--) {
                        if (AreNeighbours(inMaze.visited[j], inMaze.visited[i])) {
                            addWayBack(inMaze, i, j);
                            break;
                        }
                    }
                }
            }
        }

        private static void addWayBack(Maze inMaze, int i, int j) {
            for (int k = j; k < i - 1; k++) {
                inMaze.visited.Insert(i, new Cell(
                    inMaze.visited[k].X,
                    inMaze.visited[k].Y)
                {
                    IsVisited = true,
                });
            }
        }


        public static bool AreNeighbours(Cell start, Cell click) {
            return (start.X + 1 == click.X && start.Y == click.Y) ||
                   (start.X - 1 == click.X && start.Y == click.Y) ||
                   (start.Y + 1 == click.Y && start.X == click.X) ||
                   (start.Y - 1 == click.Y && start.X == click.X);
        }
    }
}