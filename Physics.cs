using System.Collections.Generic;
using Microsoft.Xna.Framework;
using MonogameTest.Elements;

namespace MonogameTest
{
    public static class Physics
    {
        private static Vector2 gravity = new Vector2(0, 9.8f);

        public static void UpdateElements(List<GameElement> elements, GameTime gameTime) {
            UpdateAcceleration(elements);
            UpdateSpeed(elements);
            UpdatePosition(elements, gameTime);
        }

        private static void UpdateAcceleration(List<GameElement> elements) {
            foreach (var element in elements) {
                element.Acceleration = gravity;
            }
        }

        private static void UpdateSpeed(List<GameElement> elements) {
            foreach (var element in elements) {
                element.Speed = element.Acceleration + element.Speed;
            }
        }

        private static void UpdatePosition(List<GameElement> elements, GameTime gameTime) {
            foreach (var element in elements) {
                var dy = element.Speed.Y * (float) gameTime.ElapsedGameTime.TotalSeconds;
                var dx = element.Speed.X * (float) gameTime.ElapsedGameTime.TotalSeconds;

                element.Position.Y += dy;
                element.Position.X += dx;
            }
        }
    }
}