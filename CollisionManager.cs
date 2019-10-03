using System.Collections.Generic;
using MonogameTest.Elements;

namespace MonogameTest
{
    public class CollisionManager
    {
        private GameElementsService _gameElementsService;

        public CollisionManager(GameElementsService gameElementsService) {
            this._gameElementsService = gameElementsService;
        }

        public List<GameElement> ElementCollisions(GameElement sourceElement) {
            return this._gameElementsService.GameElements.FindAll((GameElement element) => {
                return sourceElement.CollisionBounds.Intersects(element.CollisionBounds);
            });
        }
    }
}