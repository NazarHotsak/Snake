using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class CreateGamesOblects
    {
        public static Snake GetObjectSnake()
        {
            Snake snake = new Snake();

            byte cуnterWidth = Scene.SceneWidth / 2;

            ItemPlacement placeItem = new ItemPlacement() { Item = snake.Head, X = cуnterWidth, Y = Scene.SceneHeight / 2 };

            snake.SnakeBody.Add(placeItem);

            cуnterWidth--;

            placeItem = new ItemPlacement() { Item = snake.TorsoOne, X = cуnterWidth, Y = Scene.SceneHeight / 2 };

            snake.SnakeBody.Add(placeItem);

            cуnterWidth--;

            placeItem = new ItemPlacement() { Item = snake.TailOfTorso, X = cуnterWidth, Y = Scene.SceneHeight / 2 };

            snake.SnakeBody.Add(placeItem);

            snake.Movement = MovementSnake.Right;

            snake.TrueSizeOfSnakeBody = snake.SnakeBody.Count;

            return snake;
        }

        public static Food GetFood()
        {
            Food score = new Food();

            Random random = new Random();

            score.ItemPlacement.X = (byte)random.Next(1, Scene.SceneWidth - 1);

            score.ItemPlacement.Y = (byte)random.Next(1, Scene.SceneHeight - 1);

            score.ItemPlacement.Item = score.ScoreItem;

            return score;
        }
    }
}



