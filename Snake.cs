using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    internal class Snake
    {
        public readonly char Head = '@';
        public readonly char TorsoOne = 'O';
        public readonly char TorsoTwo = '0';
        public readonly char TailOfTorso = 'o';
        public const byte IndexOfHead = 0;
        public MovementSnake Movement;
        public int TrueSizeOfSnakeBody;
        public List<SetTimesIncreaseSnake> SetTimesIncreaseSnake;

        public List<ItemPlacement> SnakeBody;

        public Snake()
        {
            SnakeBody = new List<ItemPlacement>();
            SetTimesIncreaseSnake = new List<SetTimesIncreaseSnake>();
        }

        public void IncreaceTheSizeOfSnakeBody(byte newItemX,byte newItenY)
        {
            if (SnakeBody[^2].Item == TorsoOne)
            {
                SnakeBody[^1].Item = TorsoTwo;
            }
            else
            {
                SnakeBody[^1].Item = TorsoOne;
            }

            Random random = new Random();

            ItemPlacement gameObjeckPlaceItem = new ItemPlacement() 
            {
                Item = this.TailOfTorso,
                X = newItemX,
                Y = newItenY 
            };

            SnakeBody.Add(gameObjeckPlaceItem);
        }

        public bool IsTorsoCollision()
        {
            for (int i = 1; i < SnakeBody.Count; i++)
            {
                if (SnakeBody[Snake.IndexOfHead].Y == SnakeBody[i].Y && SnakeBody[Snake.IndexOfHead].X == SnakeBody[i].X)
                {
                    return true;
                }
            }

            return false;
        }

        public int Speed()
        {
            if (Movement == MovementSnake.Top || Movement == MovementSnake.Bottom)
            {
                return 85;
            }
            return 50;
        }
        //35
    }
}
