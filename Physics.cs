using System.Collections.Generic;
using Microsoft.Xna.Framework;
using MonogameTest.Elements;

namespace MonogameTest
{
    public class Physics
    {
        private static Vector2 gravity = new Vector2(0, 9.8f);
        private GameElementsService elementsService;

        public Physics(GameElementsService elementsService) {
            this.elementsService = elementsService;
        }

        public void UpdateElements(GameTime gameTime) {
            this.UpdateAcceleration();
            this.UpdateSpeed();
            this.UpdatePosition(gameTime);
        }

        private void UpdateAcceleration() {
            foreach (var element in this.elementsService.KineticElements) {
                element.Acceleration = gravity;
            }
        }

        private void UpdateSpeed() {
            foreach (var element in this.elementsService.KineticElements) {
                element.Speed = element.Acceleration + element.Speed;
            }
        }

        private void UpdatePosition(GameTime gameTime) {
            foreach (var element in this.elementsService.KineticElements) {
                var dy = element.Speed.Y * (float) gameTime.ElapsedGameTime.TotalSeconds;
                var dx = element.Speed.X * (float) gameTime.ElapsedGameTime.TotalSeconds;

                var position = element.Position;
                position.Y += dy;
                position.X += dx;
                element.Position = position;
            }
        }
    }
}