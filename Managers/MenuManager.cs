﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Warlocked
{
    public class MenuManager
    {
        Menu menu;
        bool isTransitioning;

        void Transition(GameTime gameTime)
        {
            if(isTransitioning)
            {
                
                for (int i = 0; i < menu.items.Count; i++)
                {
                    menu.items[i].image.Update(gameTime);
                    float first = menu.items[0].image.alpha;
                    float last = menu.items[menu.items.Count - 1].image.alpha;
                    if (first == 0.0f && last == 0.0f)
                        menu.ID = menu.items[menu.ItemNumber].LinkID;
                    else if (first == 1.0f && last == 1.0f)
                    {
                        isTransitioning = false;
                        foreach (MenuItem item in menu.items)
                            item.image.RestoreEffects();
                    }
                }
            }
        }
        public MenuManager()
        {
            menu = new Menu();
            menu.OnMenuChange += menu_OnMenuChange;
        }

        void menu_OnMenuChange(object sender, EventArgs e)
        {
            XmlManager<Menu> xmlMenuManager = new XmlManager<Menu>();
            menu.UnloadContent();
            menu = xmlMenuManager.Load(menu.ID);
            menu.LoadContent();
            menu.OnMenuChange += menu_OnMenuChange;
            menu.Transition(0.0f);

            foreach (MenuItem item in menu.items)
            {
                item.image.StoreEffects();
                item.image.ActivateEffect("FadeEffect");
            }
        }
        public void LoadContent(string menuPath)
        {
            if (menuPath != String.Empty)
                menu.ID = menuPath;
        }
        public void UnloadContent()
        {
            menu.UnloadContent();
        }
        public void Update(GameTime gameTime)
        {
            if (!isTransitioning)
                menu.Update(gameTime);
            if ((InputManager.Instance.KeyPressed(Keys.Enter) || 
                InputManager.Instance.ButtonPressed(Buttons.A)) && !isTransitioning)
            {
                if (menu.items[menu.ItemNumber].LinkType == "Screen")
                    ScreenManager.Instance.ChangeScreens(menu.items[menu.ItemNumber].LinkID);
                else
                {
                    isTransitioning = true;
                    menu.Transition(1.0f);
                    foreach (MenuItem item in menu.items)
                    {
                        item.image.StoreEffects();
                        item.image.ActivateEffect("FadeEffect");
                    }
                }
            }
            Transition(gameTime);
        }
        public void Draw()
        {
            menu.Draw();
        }
    }
}
