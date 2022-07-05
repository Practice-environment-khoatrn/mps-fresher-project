using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.MyInputManager
{
    internal class MyButton
    {
        private bool _isPressed = false;

        private MyButton()
        {
        }

        public static MyButton InstantiateMyButton(string name)
        {
            var myButton = new MyButton();
            MyInputManager.RegisterButton(name, myButton);
            return myButton;
        }

        public void SetPressDown()
        {
            _isPressed = true;
        }

        public void SetPressUp()
        {
            _isPressed = false;
        }

        public bool GetPressState()
        {
            return _isPressed;
        }
    }
}
