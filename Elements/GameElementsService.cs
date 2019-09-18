using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MonogameTest.Elements
{
    public class GameElementsService
    {
        private List<KineticElement> _kineticElements;

        public List<GameElement> GameElements;

        public ReadOnlyCollection<KineticElement> KineticElements;
        
        public GameElementsService() {
            this.GameElements = new List<GameElement>();
            this._kineticElements = new List<KineticElement>();
            this.KineticElements = new ReadOnlyCollection<KineticElement>(this._kineticElements);
        }

        public void AddKineticElement(KineticElement element) {
            this._kineticElements.Add(element);
            this.GameElements.Add(element);
        }
    }
}