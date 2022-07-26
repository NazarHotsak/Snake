using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Engine
    {
        private Scene _scene;
        private RenderScane _renderScane;
        private bool _mayChangeMovementSnake = true;
        private Random _random;
        private bool _doesGameRepeat;

        public Engine()
        {
            _scene = new Scene();
            _renderScane = new RenderScane();
            _random = new Random();
            _doesGameRepeat = false;
            
        }

        public void Run()
        {
            Thread.Sleep(2000);
            _renderScane.Render(_scene);

            do
            {
                MoveSnake();
                _mayChangeMovementSnake = true;

                if (_scene.Snake.IsTorsoCollision() || DidSnakeRunIntoBorder())
                {
                    _doesGameRepeat = true;
                }

                SnakeEatFood();
   

                if (_doesGameRepeat)
                {
                    Console.ReadKey(intercept: true);
                    _scene.Snake = CreateGamesOblects.GetObjectSnake();
                    NewPlacementFood();
                    _doesGameRepeat = false;
                }

                _renderScane.Render(_scene);

                Thread.Sleep(_scene.Snake.Speed());

            } while (true);
        }

        private void MoveSnake()
        {
            for (int i = _scene.Snake.SnakeBody.Count - 1; i > 0; i--)
            {
                _scene.Snake.SnakeBody[i].X = _scene.Snake.SnakeBody[i - 1].X;
                _scene.Snake.SnakeBody[i].Y = _scene.Snake.SnakeBody[i - 1].Y;
            }


            if (_scene.Snake.Movement == MovementSnake.Left)
            {
                _scene.Snake.SnakeBody[Snake.IndexOfHead].X--;
            }
            else if (_scene.Snake.Movement == MovementSnake.Right)
            {
                _scene.Snake.SnakeBody[Snake.IndexOfHead].X++;
            }
            else if (_scene.Snake.Movement == MovementSnake.Top)
            {
                _scene.Snake.SnakeBody[Snake.IndexOfHead].Y--;
            }
            else if (_scene.Snake.Movement == MovementSnake.Bottom)
            {
                _scene.Snake.SnakeBody[Snake.IndexOfHead].Y++;
            }
        }

        private void SnakeEatFood()
        {
            if (_scene.Snake.SnakeBody[Snake.IndexOfHead].X == _scene.Food.ItemPlacement.X && _scene.Snake.SnakeBody[Snake.IndexOfHead].Y == _scene.Food.ItemPlacement.Y)
            {
                _scene.Snake.TrueSizeOfSnakeBody++;
                SetTimesIncreaseSnake setTimesIncreaseSnake = new SetTimesIncreaseSnake();
                setTimesIncreaseSnake.newItemX = _scene.Food.ItemPlacement.X;
                setTimesIncreaseSnake.newItemY = _scene.Food.ItemPlacement.Y;
                setTimesIncreaseSnake.CountDown = _scene.Snake.TrueSizeOfSnakeBody;
                _scene.Snake.SetTimesIncreaseSnake.Add(setTimesIncreaseSnake);

                NewPlacementFood();
            }

            CountDownIncreaseSnape();
        }

        private void NewPlacementFood()
        {
            byte X;
            byte Y;
            bool isThereFoodUnderSnake;

            do
            {
                isThereFoodUnderSnake = false;

                X = (byte)_random.Next(1, Scene.SceneWidth - 1);
                Y = (byte)_random.Next(1, Scene.SceneHeight - 1);

                for (int i = 0; i < _scene.Snake.SnakeBody.Count; i++)
                {
                    if (_scene.Snake.SnakeBody[i].X == X && _scene.Snake.SnakeBody[i].Y == Y)
                    {
                        isThereFoodUnderSnake = true;
                        break;
                    }
                }

            } while (isThereFoodUnderSnake);


            _scene.Food.ItemPlacement.X = X;
            _scene.Food.ItemPlacement.Y = Y;
        }

        private void CountDownIncreaseSnape()
        {
            if (_scene.Snake.SetTimesIncreaseSnake.Count == 0)
            {
                return;
            }

            int i = 0;
            while (i < _scene.Snake.SetTimesIncreaseSnake.Count)
            {
                if (_scene.Snake.SetTimesIncreaseSnake[i].CountDown == 1)
                {
                    _scene.Snake.IncreaceTheSizeOfSnakeBody(_scene.Snake.SetTimesIncreaseSnake[i].newItemX, _scene.Snake.SetTimesIncreaseSnake[i].newItemY);
                    _scene.Snake.SetTimesIncreaseSnake.RemoveAt(i);
                    continue;
                }
                else
                {
                    _scene.Snake.SetTimesIncreaseSnake[i].CountDown--;
                }
                i++;
            }
        }

        private bool DidSnakeRunIntoBorder()
        {
            if (_scene.Snake.SnakeBody[Snake.IndexOfHead].Y == 0 || _scene.Snake.SnakeBody[Snake.IndexOfHead].Y == Scene.SceneHeight - 1)
            {
                return true;
            }
            if (_scene.Snake.SnakeBody[Snake.IndexOfHead].X == 0 || _scene.Snake.SnakeBody[Snake.IndexOfHead].X == Scene.SceneWidth - 1)
            {
                return true;
            }
            return false;
        }

        public bool ChangeMovementOfSnakeToLeft()
        {
            if (_mayChangeMovementSnake)
            {
                _scene.Snake.Movement = MovementSnake.Left;
                _mayChangeMovementSnake = false;
                return false;
            }
            return true;
        }

        public bool ChangeMovementOfSnakeToRight()
        {
            if (_mayChangeMovementSnake)
            {
                _scene.Snake.Movement = MovementSnake.Right;
                _mayChangeMovementSnake = false;
                return false;
            }
            return true;
        }

        public bool ChangeMovementOfSnakeToTop()
        {
            if (_mayChangeMovementSnake)
            {
                _scene.Snake.Movement = MovementSnake.Top;
                _mayChangeMovementSnake = false;
                return false;
            }
            return true;
        }

        public bool ChangeMovementOfSnakeToBottom()
        {
            if (_mayChangeMovementSnake)
            {
                _scene.Snake.Movement = MovementSnake.Bottom;
                _mayChangeMovementSnake = false;
                return false;
            }
            return true;
        }

        public MovementSnake GetMovementSnake()
        {
            return _scene.Snake.Movement;
        }
    }
}



