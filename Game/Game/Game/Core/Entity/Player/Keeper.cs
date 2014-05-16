using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game
{
    public class Keeper : HUDEffects
    {
        // Fields.

        #region Stats
        private int mana;
        private int money, maxMoney;
        private Cursor cursor;
        private HUD hud;
        private List<IA> IAs;
        private Rectangle fieldBox24, fieldBox50, fieldBox100;
        private Color[] textureData24, textureData50, textureData100;
        private bool enabledTrap1, enabledTrap2, enabledTrap3, enabledTrap4, enabledSpell1,
            enabledSpell2, enabledSpell3, enabledSpell4, enabledMob1, enabledMob2, enabledMob3, enabledMob4;
        // Timer
        private float countDuration, currentTime;
        #endregion

        // Constructor.

        public Keeper(Cursor cursor, HUD hud, ref List<IA> listIA, int mana, int money, int maxMoney)
        {
            this.IAs = listIA;
            this.countDuration = 1f;
            this.currentTime = 0f;
            this.cursor = cursor;
            this.hud = hud;
            this.mana = mana;
            this.money = money;
            this.maxMoney = maxMoney;
            enabledTrap1 = false;
            enabledTrap2 = false;
            enabledTrap3 = false;
            enabledTrap4 = false;
            enabledSpell1 = false;
            enabledSpell2 = false;
            enabledSpell3 = false;
            enabledSpell4 = false;
            enabledMob1 = false;
            enabledMob2 = false;
            enabledMob3 = false;
            enabledMob4 = false;
            /* Texture Data */
            textureData24 = new Color[Ressources.f_24.Height * Ressources.f_24.Width];
            Ressources.f_24.GetData(textureData24);
            textureData50 = new Color[Ressources.f_50.Height * Ressources.f_50.Width];
            Ressources.f_50.GetData(textureData50);
            textureData100 = new Color[Ressources.f_100.Height * Ressources.f_100.Width];
            Ressources.f_100.GetData(textureData100);
        }

        // Get & Set.
        #region Get & Set.
        public int MANA
        {
            get { return mana; }
            set { mana = value; }
        }
        public int MONEY
        {
            get { return money; }
            set { money = value; }
        }
        public Rectangle FieldBox100
        {
            get { return fieldBox100; }
            set { fieldBox100 = value; }
        }
        public Rectangle FieldBox50
        {
            get { return fieldBox50; }
            set { fieldBox50 = value; }
        }
        public Rectangle FieldBox24
        {
            get { return fieldBox24; }
            set { fieldBox24 = value; }
        }
        public List<IA> IAS
        {
            get { return IAs; }
            set { IAs = value; }
        }
        public Color[] TextureData100
        {
            get { return textureData100; }
            set { textureData100 = value; }
        }
        public Color[] TextureData50
        {
            get { return textureData50; }
            set { textureData50 = value; }
        }
        public Color[] TextureData24
        {
            get { return textureData24; }
            set { textureData24 = value; }
        }
        #endregion

        // Methods.
        private void MinusMana(int cost)
        {
            if (mana > cost)
            {
                mana -= cost;
            }
            else
            {
                mana = 0;
            }
        }
        public void MinusMoney(int cost)
        {
            if (money > cost)
            {
                money -= cost;
            }
            else
            {
                money = 0;
            }
        }
        private void AddMana(GameTime time)
        {
            currentTime += (float)time.ElapsedGameTime.TotalSeconds;
            if (currentTime >= countDuration)
            {
                if (mana > 500)
                {
                    mana = 500;
                }
                else
                {
                    mana += 4;
                }
                currentTime -= countDuration;
            }
        }

        // Update & Draw.
        public void Update(Game1 game, GameTime time, KeyboardState keyboard, MouseState mouse)
        {
            AddMana(time);
            fieldBox24 = new Rectangle(cursor.Rect.Center.X - 24, cursor.Rect.Center.Y - 24, 24, 24);
            fieldBox50 = new Rectangle(cursor.Rect.Center.X - 50, cursor.Rect.Center.Y - 50, 50, 50);
            fieldBox100 = new Rectangle(cursor.Rect.Center.X - 100, cursor.Rect.Center.Y - 100, 100, 100);
            if (Inputs.isKeyRelease(game.MAIN.HOTKEYS.Pause))
            {
                function("PAUSE");
            }
            if (Inputs.isKeyRelease(game.MAIN.HOTKEYS.Trap1) && mana > 20)
            {
                MinusMana(20);
                enabledTrap1 = true;
            }
            else if (Inputs.isLMBClick()) { if (enabledTrap1) { k_function(this, ref IAs, "TRAP1"); } enabledTrap1 = false; }
            if (Inputs.isKeyRelease(game.MAIN.HOTKEYS.Trap2) && mana > 30)
            {
                MinusMana(30);
                enabledTrap2 = true;
            }
            else if (Inputs.isLMBClick()) { if (enabledTrap2) { k_function(this, ref IAs, "TRAP2"); } enabledTrap2 = false; }
            if (Inputs.isKeyRelease(game.MAIN.HOTKEYS.Trap3) && mana > 35) 
            {
                MinusMana(35);
                enabledTrap3 = true;
            }
            else if (Inputs.isLMBClick()) { if (enabledTrap3) { k_function(this, ref IAs, "TRAP3"); } enabledTrap3 = false; }
            if (Inputs.isKeyRelease(game.MAIN.HOTKEYS.Trap4) && mana > 55)
            {
                MinusMana(55);
                enabledTrap4 = true;
            }
            else if (Inputs.isLMBClick()) { if (enabledTrap4) { k_function(this, ref IAs, "TRAP4"); } enabledTrap4 = false; }
            if (Inputs.isKeyRelease(game.MAIN.HOTKEYS.Spell1) && mana > 20)
            {
                MinusMana(20);
                enabledSpell1 = true;
            }
            else if (Inputs.isLMBClick()) { if (enabledSpell1) { k_function(this, ref IAs, "SPELL1"); } enabledSpell1 = false; }
            if (Inputs.isKeyRelease(game.MAIN.HOTKEYS.Spell2) && mana > 30)
            {
                MinusMana(30);
                enabledSpell2 = true;
            }
            else if (Inputs.isLMBClick()) { if (enabledSpell2) { k_function(this, ref IAs, "SPELL2"); } enabledSpell2 = false; }
            if (Inputs.isKeyRelease(game.MAIN.HOTKEYS.Spell3) && mana > 35)
            {
                MinusMana(35);
                enabledSpell3 = true;
            }
            else if (Inputs.isLMBClick()) { if (enabledSpell3) { k_function(this, ref IAs, "SPELL3"); } enabledSpell3 = false; }
            if (Inputs.isKeyRelease(game.MAIN.HOTKEYS.Spell4) && mana > 55)
            {
                MinusMana(55);
                enabledSpell4 = true;
            }
            else if (Inputs.isLMBClick()) { if (enabledSpell4) { k_function(this, ref IAs, "SPELL4"); } enabledSpell4 = false; }
            if (Inputs.isKeyRelease(game.MAIN.HOTKEYS.Mob1) && money > 50)
            {
                MinusMoney(50);
                enabledMob1 = true;
            }
            else if (Inputs.isLMBClick()) { if (enabledMob1) { k_function(this, ref IAs, "MOB1"); } enabledMob1 = false; }
            if (Inputs.isKeyRelease(game.MAIN.HOTKEYS.Mob2) && money > 100)
            {
                MinusMoney(100);
                enabledMob2 = true;
            }
            else if (Inputs.isLMBClick()) { if (enabledMob2) { function("MOB2"); } enabledMob2 = false; }
            if (Inputs.isKeyRelease(game.MAIN.HOTKEYS.Mob3) && money > 200)
            {
                MinusMoney(200);
                enabledMob3 = true;
            }
            else if (Inputs.isLMBClick()) { if (enabledMob3) { function("MOB3"); } enabledMob3 = false; }
            if (Inputs.isKeyRelease(game.MAIN.HOTKEYS.Mob4) && money > 400)
            {
                MinusMoney(400);
                enabledMob4 = true;
            }
            else if (Inputs.isLMBClick()) { if (enabledMob4) { function("MOB4"); } enabledMob4 = false; }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            // Cadre
            spriteBatch.Draw(Ressources.k_cadre, new Vector2(475, 633), Color.White);
            // Mana
            spriteBatch.Draw(Ressources.k_mana, new Rectangle(583, 642, (mana * 361)/500, 27), new Rectangle(0, 0, 361, 27), Color.White);
            spriteBatch.DrawString(Ressources.medieval, "Mana", new Vector2(505, 644), Color.White);
            // Money
            spriteBatch.Draw(Ressources.k_money, new Rectangle(583, 678, (money * 361) / maxMoney, 27), new Rectangle(0, 0, 361, 27), Color.White);
            spriteBatch.DrawString(Ressources.medieval, "Money", new Vector2(505, 680), Color.White);
            // HUDButtons Validate
            if (enabledTrap1) 
            { 
                spriteBatch.Draw(Ressources.k_validate, new Rectangle(205, 30, 50, 50), Color.White);
                spriteBatch.Draw(Ressources.k_field, fieldBox50, new Rectangle(0, 0, 50, 50), Color.Red);
            }
            if (enabledTrap2) 
            { 
                spriteBatch.Draw(Ressources.k_validate, new Rectangle(267, 30, 50, 50), Color.White);
                spriteBatch.Draw(Ressources.k_field, fieldBox100, new Rectangle(0, 0, 100, 100), Color.Purple);
            }
            if (enabledTrap3) 
            { 
                spriteBatch.Draw(Ressources.k_validate, new Rectangle(335, 30, 50, 50), Color.White);
                spriteBatch.Draw(Ressources.k_field, fieldBox50, new Rectangle(0, 0, 50, 50), Color.Orange);
            }
            if (enabledTrap4) 
            { 
                spriteBatch.Draw(Ressources.k_validate, new Rectangle(399, 30, 50, 50), Color.White);
                spriteBatch.Draw(Ressources.k_field, fieldBox24, new Rectangle(0, 0, 24, 24), Color.Silver);
            }
            if (enabledSpell1) 
            { 
                spriteBatch.Draw(Ressources.k_validate, new Rectangle(482, 30, 50, 50), Color.White);
                spriteBatch.Draw(Ressources.k_field, fieldBox100, new Rectangle(0, 0, 100, 100), Color.Blue);
            }
            if (enabledSpell2) { spriteBatch.Draw(Ressources.k_validate, new Rectangle(548, 30, 50, 50), Color.White); }
            if (enabledSpell3) 
            { 
                spriteBatch.Draw(Ressources.k_validate, new Rectangle(610, 30, 50, 50), Color.White);
                spriteBatch.Draw(Ressources.k_field, fieldBox24, new Rectangle(0, 0, 24, 24), Color.Red);
            }
            if (enabledSpell4) { spriteBatch.Draw(Ressources.k_validate, new Rectangle(678, 30, 50, 50), Color.White); }
            if (enabledMob1) 
            { 
                spriteBatch.Draw(Ressources.k_validate, new Rectangle(762, 30, 50, 50), Color.White);
                spriteBatch.Draw(Ressources.k_field, fieldBox24, new Rectangle(0, 0, 24, 24), Color.Red);
            }
            if (enabledMob2) { 
                spriteBatch.Draw(Ressources.k_validate, new Rectangle(827, 30, 50, 50), Color.White);
                spriteBatch.Draw(Ressources.k_field, fieldBox24, new Rectangle(0, 0, 24, 24), Color.Red);
            }
            if (enabledMob3) { 
                spriteBatch.Draw(Ressources.k_validate, new Rectangle(890, 30, 50, 50), Color.White);
                spriteBatch.Draw(Ressources.k_field, fieldBox24, new Rectangle(0, 0, 24, 24), Color.Red);
            }
            if (enabledMob4) { 
                spriteBatch.Draw(Ressources.k_validate, new Rectangle(957, 30, 50, 50), Color.White);
                spriteBatch.Draw(Ressources.k_field, fieldBox24, new Rectangle(0, 0, 24, 24), Color.Red);
            }
        }
    }
}
