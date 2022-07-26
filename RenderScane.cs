using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class RenderScane
    {
        private char[,] _screen;

        public RenderScane()
        {
            _screen = new char[Scene.SceneHeight, Scene.SceneWidth];

            Console.SetWindowSize(Scene.SceneWidth + 10, Scene.SceneHeight + 10);

            Console.SetBufferSize(Scene.SceneWidth + 10, Scene.SceneHeight + 10);

            Console.CursorVisible = false;
        }

        public void Render(Scene scene)
        {
            AddSceneSnake(scene.Snake);

            AddSceneItem(scene.Food.ItemPlacement);

            AddScreneBorder();

            StringBuilder builderScreen = new StringBuilder();

            for (int y = 0; y < Scene.SceneHeight; y++)
            {
                for (int x = 0; x < Scene.SceneWidth; x++)
                {
                    builderScreen.Append(_screen[y, x]);
                }

                builderScreen.Append(Environment.NewLine);
            }

            Console.WriteLine(builderScreen.ToString());

            ScreenClear();

            Console.SetCursorPosition(0, 0);
        }

        private void AddSceneItem(ItemPlacement placeItem)
        {
            if ((0 <= placeItem.Y && Scene.SceneHeight > placeItem.Y) && (0 < placeItem.X && Scene.SceneWidth > placeItem.X))
            {
                _screen[placeItem.Y, placeItem.X] = placeItem.Item;
            }
        }

        private void AddSceneSnake(Snake objectSnake)
        {
            for (int i = 0; i < objectSnake.SnakeBody.Count; i++)
            {
                AddSceneItem(objectSnake.SnakeBody[i]);       
            }
        }

        private void AddScreneBorder()
        {
            for (int i = 0; i < Scene.SceneWidth; i++)
            {
                _screen[0, i] = Scene.Border;
                _screen[Scene.SceneHeight - 1, i] = Scene.Border;
            }

            for (int i = 1; i < Scene.SceneHeight - 1; i++)
            {
                _screen[i, 0] = Scene.Border;
                _screen[i, Scene.SceneWidth - 1] = Scene.Border;
            }
        }

        private void ScreenClear()
        {
            for (int y = 0; y < Scene.SceneHeight; y++)
            {
                for (int x = 0; x < Scene.SceneWidth; x++)
                {
                    _screen[y, x] = ' ';
                }
            }
        }
    }
}






