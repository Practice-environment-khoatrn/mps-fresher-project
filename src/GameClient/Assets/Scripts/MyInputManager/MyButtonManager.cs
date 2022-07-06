using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.MyInputManager
{
    internal class MyButtonManager : MonoBehaviour
    {
        [SerializeField]
        private string _buttonName;
        
        private MyButton _myButton;

        private void Awake()
        {
            _myButton = MyButton.InstantiateMyButton(_buttonName);
        }

        public void SetPressDown()
        {
            _myButton.SetPressDown();
        }

        public void SetPressUp()
        {
            _myButton.SetPressUp();
        }
    }
}
