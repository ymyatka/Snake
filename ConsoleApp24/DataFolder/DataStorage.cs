using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp24.Models
{
    public class DataStorage
    {
        public string pathToStorage = "C:\\GameData";
        public string leaderBoardFileName = "LeaderBoard.txt";
        public DataStorage(string pathToStorage_, string leaderBoardFileName_)
        {
            pathToStorage = pathToStorage_;
            leaderBoardFileName = leaderBoardFileName_;

            if (!Directory.Exists(pathToStorage_) )
            {
                Directory.CreateDirectory(pathToStorage_);         
            }
            if (!File.Exists(Path.Combine(pathToStorage_, leaderBoardFileName)))
            {
                File.Create(Path.Combine(pathToStorage_, leaderBoardFileName));
            }
        }
        public void SaveRecords(List<Player> players)
        {
            using (StreamWriter sw = new StreamWriter(Path.Combine(pathToStorage, leaderBoardFileName)))
            {
                sw.Write(JsonConvert.SerializeObject(players));
            }
        }
        public void LoadRecords(List<Player> players)
        {
            using (StreamReader sr = new StreamReader(Path.Combine(pathToStorage, leaderBoardFileName)))
            {
                    players.AddRange(JsonConvert.DeserializeObject<List<Player>>(sr.ReadToEnd()));
            }
        }
    }
}
