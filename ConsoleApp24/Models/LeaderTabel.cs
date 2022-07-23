using ConsoleApp24.Enum;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp24.Models
{
    public class LeaderTabel
    {
        int height = 22;
        int width = 60;
        public List<Player> players = new List<Player>();

        public void PrintAllMenu()
        {
            Console.Clear();

            Console.SetWindowSize(61, 30);

            Line LeftWall = new Line(0, 1, height - 1, LineType.Vertical, ConsoleColor.Yellow, '|');
            Line RightWall = new Line(width, 1, height - 1, LineType.Vertical, ConsoleColor.Yellow, '|');

            Line UpWall = new Line(0, 0, width + 1, LineType.Horizontal, ConsoleColor.Yellow, '-');
            Line DownWall = new Line(0, height, width + 1, LineType.Horizontal, ConsoleColor.Yellow, '-');

            LeftWall.Draw();
            RightWall.Draw();
            UpWall.Draw();
            DownWall.Draw();

            Line Divider = new Line(1, 3, width - 1, LineType.Horizontal, ConsoleColor.Yellow, '-');

            Console.SetCursorPosition(24, 1);
            Console.Write("ТАБЛИЦА");
            Console.SetCursorPosition(24, 2);
            Console.Write("ЛИДЕРОВ");

            Divider.Draw();

            int numOfButton = 1;

            var players_ = players.OrderByDescending(p => p.Record).Distinct().Take(5);

            foreach (var player in players_)
            {
                PrintPointOfMenu(numOfButton, player.Name + "                " + player.Record);
                numOfButton++;
            }

            Console.ReadKey();
            Console.Clear();
        }

        public void PrintPointOfMenu(int buttonNum, string buttonText)
        {
            int X = 5;
            int startY = 7;
            int buttonHeight = 2;
            int buttonWidth = 50;

            int Y = buttonHeight * (buttonNum - 1) + startY;

            Line lineDown = new Line(X, Y + buttonHeight, buttonWidth, LineType.Horizontal, ConsoleColor.Yellow, '-');
            Line lineUp = new Line(X, Y, buttonWidth, LineType.Horizontal, ConsoleColor.Yellow, '-');
            Line lineLeft = new Line(X, Y, buttonHeight + 1, LineType.Vertical, ConsoleColor.Yellow, '|');
            Line lineRight = new Line(buttonWidth + X, Y, buttonHeight + 1, LineType.Vertical, ConsoleColor.Yellow, '|');
            lineDown.Draw();
            lineUp.Draw();
            lineLeft.Draw();
            lineRight.Draw();

            Console.SetCursorPosition(X + 1, Y + 1);
            Console.Write(buttonText);
        }
    }
}
