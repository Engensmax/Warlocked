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

        public string axis;
        public string effects;
        [XmlElement("item")]
        public List<MenuItem> items;
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
            foreach(MenuItem item in items)
            {
                item.image.isActive = true;
                item.image.alpha = alpha;
                if (alpha == 0.0f)
                    item.image.fadeEffect.increase = true;
                else
                    item.image.fadeEffect.increase = false;
            }
        }

        void AlignMenuItems()
        {
            Vector2 dimensions = Vector2.Zero;
            foreach (MenuItem item in items)
                dimensions += new Vector2(item.image.sourceRect.Width,
                    item.image.sourceRect.Height);

            dimensions = new Vector2((ScreenManager.Instance.Dimensions.X -
                dimensions.X) / 2, (ScreenManager.Instance.Dimensions.Y - dimensions.Y) / 2);

            foreach (MenuItem item in items)
            {
                if (axis == "X")
                    item.image.position = new Vector2(dimensions.X,
                        (ScreenManager.Instance.Dimensions.Y - item.image.sourceRect.Height) / 2);
                else if (axis == "Y")
                    item.image.position = new Vector2((ScreenManager.Instance.Dimensions.X - 
                        item.image.sourceRect.Width) / 2, dimensions.Y);
                dimensions += new Vector2(item.image.sourceRect.Width,
                    item.image.sourceRect.Height);

            }

        }

        public Menu()
        {
            id = String.Empty;
            itemNumber = 0;
            effects = String.Empty;
            axis = "Y";
            items = new List<MenuItem>();
        }
        public void LoadContent()
        {
            string[] split = effects.Split(':');
            foreach(MenuItem item in items)
            {
                item.image.LoadContent();
                foreach (string s in split)
                    item.image.ActivateEffect(s);
            }
            AlignMenuItems();
        }
        public void UnloadContent()
        {
            foreach (MenuItem item in items)
                item.image.UnloadContent();

        }
        public void Update(GameTime gameTime)
        {
            if (axis == "X")
            {
                if (InputManager.Instance.KeyPressed(Keys.Right) ||
                    InputManager.Instance.ButtonPressed(Buttons.DPadRight))
                    itemNumber++;
                else if (InputManager.Instance.KeyPressed(Keys.Left) ||
                    InputManager.Instance.ButtonPressed(Buttons.DPadLeft))
                    itemNumber--;
            }
            if( axis == "Y")
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
            else if (itemNumber > items.Count - 1)
                itemNumber = items.Count - 1;

            for (int i = 0; i < items.Count; i++)
            {
                {
                    if (i == itemNumber)
                        items[i].image.isActive = true;
                    else
                        items[i].image.isActive = false;

                    items[i].image.Update(gameTime);

                }
            }
                
        }

        public void Draw()
        {
            foreach (MenuItem item in items)
                item.image.Draw();

        }
    }
}
