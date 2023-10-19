using System;
using System.Threading;

namespace console_game
{
    internal class Program
    {
        private static int _jump = 0;
        private static int _crouch = 0;
        private static int _sceneWidth = 50;
        private static int _sceneHeight = 30;
        private static Random _random = new Random();
        static void Main(string[] args)
        {
            Vector minBounds = new Vector(0, 0);
            Vector maxBounds = new Vector(_sceneWidth, _sceneHeight);
            Scene scene = new Scene(_sceneWidth, _sceneHeight);
            int highScore = 0;

            TextBox highScoreCounter = new TextBox(new Vector(_sceneWidth - 20, 0), 20, 3);
            TextBox scoreCounter = new TextBox(new Vector(_sceneWidth - 15, 2), 15, 3);

            while (true)
            {
                highScoreCounter.UpdateText($"High Score: {highScore}");

                Player player = new Player(new Vector(3, 0)) { MinBounds = minBounds, MaxBounds = maxBounds };

                GameObject obstacle1 = RandomObstacle(minBounds, maxBounds, _sceneWidth);
                Action onObstacle1Destroy = null;
                onObstacle1Destroy = () =>
                    {
                        obstacle1 = RandomObstacle(minBounds, maxBounds, _sceneWidth);
                        obstacle1.OnDestroy = onObstacle1Destroy;
                    };
                obstacle1.OnDestroy = onObstacle1Destroy;

                GameObject obstacle2 = RandomObstacle(minBounds, maxBounds, (int)(_sceneWidth * 1.5));
                Action onObstacle2Destroy = null;
                onObstacle2Destroy = () =>
                    {
                        obstacle2 = RandomObstacle(minBounds, maxBounds, _sceneWidth);
                        obstacle2.OnDestroy = onObstacle2Destroy;
                    };
                obstacle2.OnDestroy = onObstacle2Destroy;

                int score = 0;

                while (true)
                {
                    ProcessInput();
                    if (_jump > 0) player.Jump();
                    else if (_crouch > 0) player.Crouch();
                    else player.StandUp();

                    player.Move();
                    obstacle1.Move();
                    obstacle2.Move();

                    scoreCounter.UpdateText($"Score: {score}");
                    scene.Draw(player, obstacle1, obstacle2, highScoreCounter, scoreCounter);

                    if (player.CollideWith(obstacle1.Collider) || player.CollideWith(obstacle2.Collider)) break;
                    score++;
                    Thread.Sleep(100);
                }
                if (score > highScore) highScore = score;
            }
        }
        private static void ProcessInput()
        {
            if (_jump > 0) _jump--;
            if (_crouch > 0) _crouch--;
            while (Console.KeyAvailable)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                if (key.KeyChar == 'w') _jump = 5;
                else if (key.KeyChar == 's') _crouch = 5;
            }
        }
        private static GameObject RandomObstacle(Vector minBounds, Vector maxBounds, float X)
        {
            if (_random.NextDouble() > 0.5) return new Meteor(new Vector(X, _sceneHeight - 15)) { MinBounds = minBounds, MaxBounds = maxBounds };
            return new Cactus(new Vector(X, _sceneHeight - 6)) { MinBounds = minBounds, MaxBounds = maxBounds };
        }
    }
}