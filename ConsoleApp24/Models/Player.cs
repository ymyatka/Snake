namespace ConsoleApp24.Models
{
    public class Player
    {
        public string Name { get; set; }
        public int Score { get; set; }
        public int Record { get; set; }

        public Player() { }
        public Player(string name_)
        {
            Name = name_;
        }
        public Player(int record, string name) : this(name)
        {
            Record = record;
        }
    }
}
