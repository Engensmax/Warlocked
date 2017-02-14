using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Artemis;
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
            SpellButton1,
            SpellButton2,
            SpellButton3,
            Attack
        }

        public bool isActive = true;
        public Dictionary<Action, Keys> actionKeysMap;

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
                this.actionKeysMap.Add(Action.SpellButton1, Keys.Q);
                this.actionKeysMap.Add(Action.SpellButton2, Keys.E);
                this.actionKeysMap.Add(Action.SpellButton3, Keys.F);
                this.actionKeysMap.Add(Action.Attack, Keys.Space);
            }

            if (playerNumber == 2)
            {
                this.actionKeysMap = new Dictionary<Action, Keys>();
                this.actionKeysMap.Add(Action.MoveUp, Keys.I);
                this.actionKeysMap.Add(Action.MoveLeft, Keys.J);
                this.actionKeysMap.Add(Action.MoveDown, Keys.K);
                this.actionKeysMap.Add(Action.MoveRight, Keys.L);
                this.actionKeysMap.Add(Action.SpellButton1, Keys.H);
                this.actionKeysMap.Add(Action.SpellButton2, Keys.U);
                this.actionKeysMap.Add(Action.SpellButton3, Keys.O);
                this.actionKeysMap.Add(Action.Attack, Keys.Enter);
            }
        }

        public Input()
        {
        }
    }
}

