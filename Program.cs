namespace Snake
{
    public class Program
    {
        static Engine _engine;

        static UIControl _uI;

        static void Main()
        {
            Initialize();

            _engine.Run();
        }
        
        static void Initialize()
        {
            _engine = new Engine();

            _uI = new UIControl(onMoveBottom: _engine.ChangeMovementOfSnakeToBottom,
                                onMoveLeft: _engine.ChangeMovementOfSnakeToLeft,
                                onMoveRight: _engine.ChangeMovementOfSnakeToRight,
                                onMoveTop: _engine.ChangeMovementOfSnakeToTop,
                                currentMovement: _engine.GetMovementSnake);

            Thread thread = new Thread(_uI.Onclick);

            thread.Start();
        }
    }
}