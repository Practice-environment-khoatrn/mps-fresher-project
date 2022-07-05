using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.MyInputManager
{
    internal class MyInputManager
    {
        private static Dictionary<string, MyButton> s_buttons = new Dictionary<string, MyButton>();

        public static void RegisterButton(string name, MyButton button)
        {
            if (s_buttons.ContainsKey(name))
            {
                s_buttons[name] = button;
            }
            else
            {

                s_buttons.Add(name, button);
            }
        }

        public static bool GetButton(string name)
        {
            if (s_buttons.ContainsKey(name))
            {
                return s_buttons[name].GetPressState();
            } else
            {
                return false;
            }
        }
    }
}
