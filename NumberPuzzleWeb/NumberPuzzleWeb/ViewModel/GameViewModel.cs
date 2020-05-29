using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NumberPuzzleWeb.API.ViewModel
{
    public class GameViewModel
    {
        public string id { get; set; }
        public int PlayCount { get; set; }
        public bool IsSolved { get; set; }
        public char[] Numbers { get; set; }

        public GameViewModel(string id, int playCount, bool isSolved, char[] numbers)
        {
            this.id = id;
            PlayCount = playCount;
            IsSolved = isSolved;
            Numbers = numbers;
        }

        public GameViewModel()
        {
            
        }
    }
}
