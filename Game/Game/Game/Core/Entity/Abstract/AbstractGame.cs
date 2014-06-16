using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game
{
    [Serializable]
    public class AbstractGame
    {
        // Fields.
        private string version = "1.0";

        // Constructor.
        public AbstractGame() { }

        // Get & Set.
        public string Version
        {
            get { return version; }
            set { version = value; }
        }
    }
}
