using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Scene
    {
        public Snake Snake;
        public Food Food;

        public const int SceneWidth = 32;
        public const int SceneHeight = 12;
        public const char Border = '#';

        public Scene()
        {
            Snake = CreateGamesOblects.GetObjectSnake();

            Food = CreateGamesOblects.GetFood();
        }
    }
}
