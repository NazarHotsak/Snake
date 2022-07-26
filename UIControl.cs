using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    internal class UIControl
    {
        public delegate bool MovementChange();
        public delegate MovementSnake GetCurrentMovement();

        private GetCurrentMovement _currentMovement;
        private MovementChange _onMoveLeft;
        private MovementChange _onMoveRight;
        private MovementChange _onMoveTop;
        private MovementChange _onMoveBottom;

        public UIControl(MovementChange onMoveLeft, MovementChange onMoveRight, MovementChange onMoveTop, MovementChange onMoveBottom, GetCurrentMovement currentMovement)
        {
            _onMoveBottom = onMoveBottom;
            _onMoveLeft = onMoveLeft;    
            _onMoveRight = onMoveRight;
            _onMoveTop = onMoveTop;
            _currentMovement = currentMovement;
        }

        public void Onclick()
        {
            ConsoleKeyInfo Key;

            MovementSnake currentMovement;

            while (true)
            {
                Key = Console.ReadKey(true);

                currentMovement = _currentMovement();

                if (Key.Key.Equals(ConsoleKey.W) && (currentMovement == MovementSnake.Left || currentMovement == MovementSnake.Right))
                {
                    while (_onMoveTop())
                    {
                        Thread.Sleep(10);
                    }
                }
                else if (Key.Key.Equals(ConsoleKey.S) && (currentMovement == MovementSnake.Left || currentMovement == MovementSnake.Right))
                {
                    while (_onMoveBottom())
                    {
                        Thread.Sleep(10);
                    }
                }
                else if (Key.Key.Equals(ConsoleKey.D) && (currentMovement == MovementSnake.Top || currentMovement == MovementSnake.Bottom))
                {
                    while (_onMoveRight())
                    {
                        Thread.Sleep(10);
                    }
                }
                else if (Key.Key.Equals(ConsoleKey.A) && (currentMovement == MovementSnake.Top || currentMovement == MovementSnake.Bottom))
                {
                    while (_onMoveLeft())
                    {
                        Thread.Sleep(10);
                    }
                }
            }    
        }
    }
}
