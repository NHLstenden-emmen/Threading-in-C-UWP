using System;
using System.Collections.Generic;
using System.Drawing;
using Threading_in_C_UWP.Board.placeable;

namespace Threading_in_C_UWP.Board
{
    public static class Rooms
    {
        public static void drawRoom(List<Point> wallList)
        {
            foreach (Point point in wallList)
            {
                Tile tile2 = (Tile)PlayerBoard.instance.tileArray[point.Y, point.X].Tag;
                tile2.setPlaceable(new Obstacle("Wall"));

                PlayerBoard.instance.updateBoard();
            }
        }

        public static List<Point> getRoom1(int x, int y)
        {
            List<Point> wallList = new List<Point>
            {
                new Point(x, y),
                new Point(x + 1, y),
                new Point(x + 3, y),
                new Point(x + 4, y + 1),
                new Point(x + 4, y + 3),
                new Point(x + 3, y + 4),
                new Point(x + 2, y + 4),
                new Point(x + 1, y + 4),
                new Point(x, y + 4),
                new Point(x, y + 2),
                new Point(x, y + 1),
                new Point(x, y + 0)
            };

            return wallList;
        }

        public static List<Point> getRoom2(int x, int y)
        {
            List<Point> wallList = new List<Point>
            {
                new Point(x, y),
                new Point(x + 1, y),
                new Point(x + 2, y),
                new Point(x + 3, y),
                new Point(x + 3, y + 1),
                new Point(x + 3, y + 2)
            };

            return wallList;
        }

        public static List<Point> getRoom3(int x, int y)
        {
            List<Point> wallList = new List<Point>
            {
                new Point(x, y),
                new Point(x + 1, y),
                new Point(x + 3, y),
                new Point(x + 4, y + 1),
                new Point(x + 4, y + 3),
                new Point(x + 3, y + 4),
                new Point(x + 2, y + 4),
                new Point(x + 1, y + 4),
                new Point(x, y + 4),
                new Point(x, y + 2),
                new Point(x, y + 1),
                new Point(x, y + 0),
                new Point(x + 2, y + 1),
                new Point(x + 2, y + 2),
                new Point(x + 2, y + 3)
            };

            return wallList;
        }

        public static List<Point> getRoom4(int x, int y)
        {
            List<Point> wallList = new List<Point>
            {
                new Point(x, y),
                new Point(x + 1, y),
                new Point(x + 2, y),
                new Point(x + 3, y),
                new Point(x + 4, y),
                new Point(x + 5, y),
                new Point(x + 2, y + 1),
                new Point(x + 2, y + 2),
                new Point(x + 2, y + 3)
            };

            return wallList;
        }

        public static List<Point> getRoom5(int x, int y)
        {
            List<Point> wallList = new List<Point>
            {
                new Point(x, y),
                new Point(x + 1, y + 1),
                new Point(x + 2, y + 2),
                new Point(x + 2, y + 3),
                new Point(x + 3, y + 2),
                new Point(x + 4, y + 2),
                new Point(x + 4, y + 4),
                new Point(x + 3, y + 5),
                new Point(x + 2, y + 5),
                new Point(x + 1, y + 5),
                new Point(x, y + 4),
                new Point(x, y + 3),
                new Point(x, y + 2),
                new Point(x, y + 1)
            };

            return wallList;
        }

        public static List<Point> getRandomRoom(int x, int y)
        {
            Random rnd = new Random();

            switch (rnd.Next(1, 6))
            {
                case 1:
                    return getRoom1(x, y);
                case 2:
                    return getRoom2(x, y);
                case 3:
                    return getRoom3(x, y);
                case 4:
                    return getRoom4(x, y);
                case 5:
                    return getRoom5(x, y);
                default:
                    return getRoom1(x, y);
            }
        }
    }
}
