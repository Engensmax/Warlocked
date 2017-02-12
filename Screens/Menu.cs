using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Xml.Serialization;

namespace Warlocked
{
    public class Menu
    {
        public event EventHandler OnMenuChange;

        public string Axis;
        public string Effects;
        [XmlElement("item")]
        public List<MenuItem> Items;
        int itemNumber;
        string id;

        public int ItemNumber
        {
            get {return itemNumber; }
        }

        public string ID
        {
            get { return id; }
            set
            {
                id = value;
                OnMenuChange(this, null);
            }
        }

        public void Transition(float alpha)
        {
            foreach(MenuItem item in Items)
            {
                item.image.isActive = true;
                item.image.Alpha = alpha;
                if (alpha == 0.0f)
                    item.image.FadeEffect.Increase = true;
                else
                    item.image.FadeEffect.Increase = false;
            }
        }

        void AlignMenuItems()
        {
            Vector2 dimensions = Vector2.Zero;
            foreach (MenuItem item in Items)
                dimensions += new Vector2(item.image.SourceRect.Width,
                    item.image.SourceRect.Height);

            dimensions = new Vector2((ScreenManager.Instance.Dimensions.X -
                dimensions.X) / 2, (ScreenManager.Instance.Dimensions.Y - dimensions.Y) / 2);

            foreach (MenuItem item in Items)
            {
                if (Axis == "X")
                    item.image.Position = new Vector2(dimensions.X,
                        (ScreenManager.Instance.Dimensions.Y - item.image.SourceRect.Height) / 2);
                else if (Axis == "Y")
                    item.image.Position = new Vector2((ScreenManager.Instance.Dimensions.X - 
                        item.image.SourceRect.Width) / 2, dimensions.Y);
                dimensions += new Vector2(item.image.SourceRect.Width,
                    item.image.SourceRect.Height);

            }

        }

        public Menu()
        {
            id = String.Empty;
            itemNumber = 0;
            Effects = String.Empty;
            Axis = "Y";
            Items = new List<MenuItem>();
        }
        public void LoadContent()
        {
            string[] split = Effects.Split(':');
            foreach(MenuItem item in Items)
            {
                item.image.LoadContent();
                foreach (string s in split)
                    item.image.ActivateEffect(s);
            }
            AlignMenuItems();
        }
        public void UnloadContent()
        {
            foreach (MenuItem item in Items)
                item.image.UnloadContent();

        }
        public void Update(GameTime gameTime)
        {
            if (Axis == "X")
            {
                if (InputManager.Instance.KeyPressed(Keys.Right) ||
                    InputManager.Instance.ButtonPressed(Buttons.DPadRight))
                    itemNumber++;
                else if (InputManager.Instance.KeyPressed(Keys.Left) ||
                    InputManager.Instance.ButtonPressed(Buttons.DPadLeft))
                    itemNumber--;
            }
            if( Axis == "Y")
            {
                if (InputManager.Instance.KeyPressed(Keys.Down) ||
                    InputManager.Instance.ButtonPressed(Buttons.DPadDown))
                    itemNumber++;
                else if (InputManager.Instance.KeyPressed(Keys.Up) ||
                    InputManager.Instance.ButtonPressed(Buttons.DPadUp))
                    itemNumber--;
            }

            if (itemNumber < 0)
                itemNumber = 0;
            else if (itemNumber > Items.Count - 1)
                itemNumber = Items.Count - 1;

            for (int i = 0; i < Items.Count; i++)
            {
                {
                    if (i == itemNumber)
                        Items[i].image.isActive = true;
                    else
                        Items[i].image.isActive = false;

                    Items[i].image.Update(gameTime);

                }
            }
                
        }

        public void Draw()
        {
            foreach (MenuItem item in Items)
                item.image.Draw();

        }
    }
}
