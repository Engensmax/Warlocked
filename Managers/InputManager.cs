using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Warlocked
{
    class InputManager
    {
        KeyboardState currentKeyState, prevKeyState;
        GamePadState currentGamePadState, prevGamePadState;

        private static InputManager instance;

        public static InputManager Instance
        {
            get
            {
                if (instance == null)
                    instance = new InputManager();

                return instance;
            }
        }

        public void Update()
        {
            prevKeyState = currentKeyState;
            prevGamePadState = currentGamePadState;
            if (!ScreenManager.Instance.IsTransitioning)
            {
                currentKeyState = Keyboard.GetState();
                /// TODO MAX Allow multiple GamePads
                currentGamePadState = GamePad.GetState(PlayerIndex.One);
            }
        }

        public bool KeyPressed(params Keys[] keys)
        {
            foreach (Keys key in keys)
            {
                if (currentKeyState.IsKeyDown(key) && prevKeyState.IsKeyUp(key))
                    return true;
            }
            return false;
        }
        public bool KeyReleased(params Keys[] keys)
        {
            foreach (Keys key in keys)
            {
                if (currentKeyState.IsKeyUp(key) && prevKeyState.IsKeyDown(key))
                    return true;
            }
            return false;
        }
        public bool KeyDown(params Keys[] keys)
        {
            foreach (Keys key in keys)
            {
                if (currentKeyState.IsKeyDown(key))
                    return true;
            }
            return false;
        }

        public bool ButtonPressed(params Buttons[] buttons)
        {
            foreach (Buttons button in buttons)
            {
                if (currentGamePadState.IsButtonDown(button) && prevGamePadState.IsButtonUp(button))
                    return true;
            }
            return false;
        }

        public bool ButtonReleased(params Buttons[] buttons)
        {
            foreach (Buttons button in buttons)
            {
                if (currentGamePadState.IsButtonUp(button) && prevGamePadState.IsButtonDown(button))
                    return true;
            }
            return false;
        }

        public bool ButtonDown(params Buttons[] buttons)
        {
            foreach (Buttons button in buttons)
            {
                if (currentGamePadState.IsButtonDown(button))
                    return true;
            }
            return false;
        }
    }
}
