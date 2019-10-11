using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomCleanRobot
{
    class Program
    {
        static int[,] room = new int[,]
        {
             {1, 1, 1, 1, 1, 0, 1, 1},
             {1, 1, 1, 1, 1, 0, 1, 1},
             {1, 0, 1, 1, 1, 1, 1, 1},
             {0, 0, 0, 1, 0, 0, 0, 0},
             {1, 1, 1, 1, 1, 1, 1, 1 }
        };
        int x = 0;
        int y = 2;

        static void Main(string[] args)
        {
            var robot = new Robot();
            DFS(robot, new HashSet<string>(), 0, 0, 0);
        }

        private static void DFS(Robot robot, HashSet<string> hashSet, int x, int y, int v3)
        {
            throw new NotImplementedException();
        }
    }

    public class Robot
    {
        int[,] room = new int[,]
        {
             {1, 1, 1, 1, 1, 0, 1, 1},
             {1, 1, 1, 1, 1, 0, 1, 1},
             {1, 0, 1, 1, 1, 1, 1, 1},
             {0, 0, 0, 1, 0, 0, 0, 0},
             {1, 1, 1, 1, 1, 1, 1, 1 }
        };

        public void Clean()
        {
            return;
        }

        public void TurnRight()
        {
            return;
        }
        public void TurnLeft()
        {
            return;
        }
        public bool Move(int x, int y)
        {
            var res = false;

            if ((x > 0 && x < room.GetLength(0))
                && (y > 0 && y < room.GetLength(1)
                && room[x, y] == 1))
                res = true;

            return res;
        }
    }
}
