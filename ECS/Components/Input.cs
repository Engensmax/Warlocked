using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Artemis;
using Artemis.Utils;
using Microsoft.Xna.Framework.Input;

namespace Warlocked
{
    [Artemis.Attributes.ArtemisComponentPool()]
    class Input : ComponentPoolable
    {

        public enum Action
        {
            MoveUp,
            MoveDown,
            MoveLeft,
            MoveRight,
            MenuButton1,
            MenuButton2,
            MenuButton3,
            NextButton,
            BackButton,
            EscapeButton,
            Attack
        }

        public bool isActive = true;
        public Dictionary<Action, Keys> actionKeysMap;
        public Timer overstepTimer = new Timer(new TimeSpan(1000));

        public void Initialize(int playerNumber)
        {
            // MAX: Eventually load and save this via xml.
            if (playerNumber == 1)
            {
                this.actionKeysMap = new Dictionary<Action, Keys>();
                this.actionKeysMap.Add(Action.MoveUp, Keys.W);
                this.actionKeysMap.Add(Action.MoveLeft, Keys.A);
                this.actionKeysMap.Add(Action.MoveDown, Keys.S);
                this.actionKeysMap.Add(Action.MoveRight, Keys.D);
                this.actionKeysMap.Add(Action.MenuButton1, Keys.D1);
                this.actionKeysMap.Add(Action.MenuButton2, Keys.D2);
                this.actionKeysMap.Add(Action.MenuButton3, Keys.D3);
                this.actionKeysMap.Add(Action.NextButton, Keys.E);
                this.actionKeysMap.Add(Action.BackButton, Keys.Q);
                this.actionKeysMap.Add(Action.Attack, Keys.Space);
                this.actionKeysMap.Add(Action.EscapeButton, Keys.X);
            }

            if (playerNumber == 2)
            {
                this.actionKeysMap = new Dictionary<Action, Keys>();
                this.actionKeysMap.Add(Action.MoveUp, Keys.I);
                this.actionKeysMap.Add(Action.MoveLeft, Keys.J);
                this.actionKeysMap.Add(Action.MoveDown, Keys.K);
                this.actionKeysMap.Add(Action.MoveRight, Keys.L);
                this.actionKeysMap.Add(Action.MenuButton1, Keys.D7);
                this.actionKeysMap.Add(Action.MenuButton2, Keys.D8);
                this.actionKeysMap.Add(Action.MenuButton3, Keys.D9);
                this.actionKeysMap.Add(Action.NextButton, Keys.O);
                this.actionKeysMap.Add(Action.BackButton, Keys.U);
                this.actionKeysMap.Add(Action.Attack, Keys.Enter);
                this.actionKeysMap.Add(Action.EscapeButton, Keys.OemComma); 
            }
        }

        public Input()
        {
        }
    }
}

