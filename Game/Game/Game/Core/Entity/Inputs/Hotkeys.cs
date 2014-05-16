using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;

namespace Game
{
    [Serializable]
    public class Hotkeys
    {
        // Fields.
        
        /* Different keys :
        * private Keys name */
        private Keys pause, trap1, trap2, trap3, trap4, spell1, spell2, spell3,
            spell4, mob1, mob2, mob3, mob4;
        private Keys c_trap1, c_trap2, c_trap3, c_trap4, c_spell1, c_spell2, c_spell3,
            c_spell4, c_mob1, c_mob2, c_mob3, c_mob4;

        // Constructor.

        public Hotkeys() { }
        public Hotkeys(Keys pause, Keys trap1, Keys trap2, Keys trap3, Keys trap4, Keys spell1, Keys spell2, Keys spell3,
            Keys spell4, Keys mob1, Keys mob2, Keys mob3, Keys mob4)
        {
            this.pause = pause;
            this.trap1 = trap1;
            this.trap2 = trap2;
            this.trap3 = trap3;
            this.trap4 = trap4;
            this.spell1 = spell1;
            this.spell2 = spell2;
            this.spell3 = spell3;
            this.spell4 = spell4;
            this.mob1 = mob1;
            this.mob2 = mob2;
            this.mob3 = mob3;
            this.mob4 = mob4;
        }

        // Gets.
        #region Gets
        public Keys Mob4
        {
            get { return mob4; }
        }

        public Keys Mob3
        {
            get { return mob3; }
        }

        public Keys Mob2
        {
            get { return mob2; }
        }

        public Keys Mob1
        {
            get { return mob1; }
        }

        public Keys Spell4
        {
            get { return spell4; }
        }

        public Keys Spell3
        {
            get { return spell3; }
        }

        public Keys Spell2
        {
            get { return spell2; }
        }

        public Keys Spell1
        {
            get { return spell1; }
        }

        public Keys Trap4
        {
            get { return trap4; }
        }

        public Keys Trap3
        {
            get { return trap3; }
        }

        public Keys Trap2
        {
            get { return trap2; }
        }

        public Keys Trap1
        {
            get { return trap1; }
        }

        public Keys Pause
        {
            get { return pause; }
        }
        #endregion

        // Methods.
        #region SetKey
        public void SetTrap1(Keys key)
        {
            c_trap1 = key;
            Console.WriteLine("Trap 1 : {0}", c_trap1.ToString());
        }
        public void SetTrap2(Keys key)
        {
            c_trap2 = key;
            Console.WriteLine("Trap 2 : {0}", c_trap2.ToString());
        }
        public void SetTrap3(Keys key)
        {
            c_trap3 = key;
            Console.WriteLine("Trap 3 : {0}", c_trap3.ToString());
        }
        public void SetTrap4(Keys key)
        {
            c_trap4 = key;
            Console.WriteLine("Trap 4 : {0}", c_trap4.ToString());
        }
        public void SetSpell1(Keys key)
        {
            c_spell1 = key;
            Console.WriteLine("Spell 1 : {0}", c_spell1.ToString());
        }
        public void SetSpell2(Keys key)
        {
            c_spell2 = key;
            Console.WriteLine("Spell 2 : {0}", c_spell2.ToString());
        }
        public void SetSpell3(Keys key)
        {
            c_spell3 = key;
            Console.WriteLine("Spell 3 : {0}", c_spell3.ToString());
        }
        public void SetSpell4(Keys key)
        {
            c_spell4 = key;
            Console.WriteLine("Spell 4 : {0}", c_spell4.ToString());
        }
        public void SetMob1(Keys key)
        {
            c_mob1 = key;
            Console.WriteLine("Mob 1 : {0}", c_mob1.ToString());
        }
        public void SetMob2(Keys key)
        {
            c_mob2 = key;
            Console.WriteLine("Mob 2 : {0}", c_mob2.ToString());
        }
        public void SetMob3(Keys key)
        {
            c_mob3 = key;
            Console.WriteLine("Mob 3 : {0}", c_mob3.ToString());
        }
        public void SetMob4(Keys key)
        {
            c_mob4 = key;
            Console.WriteLine("Mob 4 : {0}", c_mob4.ToString());
        }
        #endregion
        public void SetHotkeysCustoms(bool custom)
        {
            this.pause = Keys.Enter;
            this.trap1 = c_trap1;
            this.trap2 = c_trap2;
            this.trap3 = c_trap3;
            this.trap4 = c_trap4;
            this.spell1 = c_spell1;
            this.spell2 = c_spell2;
            this.spell3 = c_spell3;
            this.spell4 = c_spell4;
            this.mob1 = c_mob1;
            this.mob2 = c_mob2;
            this.mob3 = c_mob3;
            this.mob4 = c_mob4;
            Console.WriteLine("Trap 1 : {0}", c_trap1.ToString());
            Console.WriteLine("Trap 2 : {0}", c_trap2.ToString());
            Console.WriteLine("Trap 3 : {0}", c_trap3.ToString());
            Console.WriteLine("Trap 4 : {0}", c_trap4.ToString());
            Console.WriteLine("Spell 1 : {0}", c_spell1.ToString());
            Console.WriteLine("Spell 2 : {0}", c_spell2.ToString());
            Console.WriteLine("Spell 3 : {0}", c_spell3.ToString());
            Console.WriteLine("Spell 4 : {0}", c_spell4.ToString());
            Console.WriteLine("Mob 1 : {0}", c_mob1.ToString());
            Console.WriteLine("Mob 2 : {0}", c_mob2.ToString());
            Console.WriteLine("Mob 3 : {0}", c_mob3.ToString());
            Console.WriteLine("Mob 4 : {0}", c_mob4.ToString());
        }

        public Hotkeys LoadHotkeys()
        {
            return Data.Deserialization(this, "Hotkeys");
        }
       
    }
}
