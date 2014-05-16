using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BinarySerialization
{
    /* Rendre la classe "Serialisable" */
    [Serializable]
    class Map
    {
        /*
         * -- Simulation de sauvegarde d'objet --
         * Vous pourrez ainsi comprendre aisemment les directives à suivres pour sauvegarder une map (très simplifiée !)
         */
         
        // Fields.

        private string texture, description;
        private int[,] tilemap;

        // Constructor.

        /* On définit un constructeur pour la serialization sans arguments, et un pour construire notre objet */
        public Map() { }
        public Map(string texture, string description, int[,] tilemap)
        {
            this.texture = texture;
            this.description = description;
            this.tilemap = tilemap;
        }

        // Get & Set.

        /* On définit les droits d'accès à nos variables de classe */
        public string Description
        {
            get { return description; }
        }
        public string Texture
        {
            get { return texture; }
        }
        public int[,] Tilemap
        {
            get { return tilemap; }
        }

        // Methods.

        /* Aucune */
    }
}
