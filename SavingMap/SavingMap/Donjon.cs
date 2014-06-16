using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace SavingMap
{
    [Serializable]
    public class Donjon
    {
        // Fields.
        private ArrayMap[] donjon;
        private Rectangle[] torchs;
        private int[] positionTorchs;

        // Constructor.
        public Donjon() { }
        public Donjon(int number, int nb_torch)
        {
            donjon = new ArrayMap[number];
            torchs = new Rectangle[nb_torch];
            positionTorchs = new int[number];
        }

        // Get & Set.
        public ArrayMap[] DonjonMaps
        {
            get { return donjon; }
            set { donjon = value; }
        }
        public Rectangle[] Torchs
        {
            get { return torchs; }
            set { torchs = value; }
        }
        public int[] PositionTorchs
        {
            get { return positionTorchs; }
            set { positionTorchs = value; }
        }
    }
}
