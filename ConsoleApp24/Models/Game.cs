using ConsoleApp24.Infrastucture;
using System;
using System.Linq;
using System.Threading;

namespace ConsoleApp24.Models
{
    public class Game
    {
        public DataStorage dataStorage = new DataStorage("C:\\GameData", "LeaderBoard.txt");
        public Snake snake;
        public IMap _map;
        private Menu menu;
        public Player player { get; private set; }
        public LeaderTabel leaderTabel { get; set; } 

        public Game()
        {
            leaderTabel = new LeaderTabel();
            menu = new Menu(this);
            player = new Player();
            dataStorage.LoadRecords(leaderTabel.players);
        }

        public Game(Player player_)
        {                 
            player = player_;
        }

        public void Start()
        {
            while (true)
            {
                menu.Print();
                menu.ChooseButton();
            }
        }

        public void Exit()
        {
            Environment.Exit(0);
        }

        public void ChangeNickName()
        {
            Console.SetCursorPosition(6, 24);
            Console.Write("Введите имя: ");
            string newName = Console.ReadLine();
            if (leaderTabel.players.Any(i => i.Name == newName))
            {
                Console.WriteLine("Это имя уже используется");
                Console.ReadKey();
                Console.Clear();
                Start();
            }
            player = new Player(newName);
            Console.Clear();
            Start();
        }

        public void Play()
        {
            player.Score = 0;
            InitGame();
            Console.SetCursorPosition(55, 2);
            Console.Write(player.Score);
            while (true)
            {                        
                if (_map.IsHit(snake) || snake.IsHitByItSelf())
                {
                    if (leaderTabel.players.Any(i => i.Name == player.Name))
                    {
                        if (player.Record < player.Score)
                        {
                            player.Record = player.Score;
                        }
                    }
                    else
                    {
                        player.Record = player.Score;
                        leaderTabel.players.Add(player);                        
                    }

                    dataStorage.SaveRecords(leaderTabel.players);
                    Console.SetCursorPosition(51,21);
                    Console.Write("Game Over");
                    Console.ReadKey();
                    Console.Clear();
                    return;
                }

                if (snake.IsAteFood(_map.Food))
                {
                    player.Score++;
                    _map.GenerateFood();
                    Console.SetCursorPosition(55, 2);
                    Console.Write(player.Score);
                }
                snake.Move();
                Thread.Sleep(100);
                if (Console.KeyAvailable)
                {
                    snake.HandleKey(Console.ReadKey().Key);
                }          
            }
        }

        private void InitGame()
        {
            Console.Clear();
            Console.SetWindowSize(111,43);
            Console.CursorVisible = false;
            InitSnake();
            InitMap(); 
        }

        private void InitMap()
        {
            MapGenerator mapGenerator = new MapGenerator();           
            _map = mapGenerator.Generate(Enum.MapType.Box);
            _map.Draw();
            _map.GenerateFood();
        }

        private void InitSnake()
        {
            Point tail = new Point(15, 20, '*', ConsoleColor.DarkCyan);
            snake = new Snake(tail, 5, Enum.MoveDirection.Right);
            snake.Draw();
        }
    }
}
