using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    internal class Food
    {
        public readonly char ScoreItem = '*';         

        public ItemPlacement ItemPlacement;

        public Food()
        {
            ItemPlacement = new ItemPlacement();
        }
    }
}
