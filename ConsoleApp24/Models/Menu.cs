using ConsoleApp24.Enum;
using System;

namespace ConsoleApp24.Models
{
    public class Menu
    {
        int height = 22;
        int width = 60;

        Game game;

        public Menu(Game game_)
        {
            game = game_;
        }

        public void Print()
        {
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
            Console.Write("ЗМЕЙКА");
            Console.SetCursorPosition(21, 2);
            Console.Write("ГЛАВНОЕ МЕНЮ");

            Divider.Draw();

            DrawButton(1, "1.Играть");
            DrawButton(2, "2.Смена ника");
            DrawButton(3, "3.Выбор карты");
            DrawButton(4, "4.Таблица рейтинга");
            DrawButton(5, "5.Выход");

            Console.SetCursorPosition(6, 19);
            Console.Write($"ник игрока: {game.player.Name}");


        }

        private void DrawButton(int buttonNum, string buttonText)
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

        public void ChooseButton()
        {
            try
            {
                Console.SetCursorPosition(6, 23);
                Console.Write("Введите пункт меню: ");
                switch (int.Parse(Console.ReadLine()))
                {
                    case (int)MenuItems.Play:
                        game.Play();
                        break;
                    case (int)MenuItems.ChangeNickName:
                        game.ChangeNickName();
                        break;
                    case (int)MenuItems.ChooseMap:
                        break;
                    case (int)MenuItems.RaitingTab:
                        game.leaderTabel.PrintAllMenu();
                        break;
                    case (int)MenuItems.Exit:
                        game.Exit();
                        break;
                }
            }
            catch (Exception)
            {
                Console.Clear();
                Console.SetCursorPosition(17, 3);
                Console.Write("Введены неверные данные");
                Console.ReadKey();
                Console.Clear();
                Print();
            }

        }
    }
}
