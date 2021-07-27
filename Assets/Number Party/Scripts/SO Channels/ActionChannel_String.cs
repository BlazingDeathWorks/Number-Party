using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace NumberParty
{
    [CreateAssetMenu(fileName = "NewActionChannel_String", menuName = "Channels/ActionChannel_String")]
    public class ActionChannel_String : ScriptableObject
    {
        private event Action<string> ActionEvent;

        public void AddAction(Action<string> func)
        {
            ActionEvent += func;
        }

        public void RemoveAction(Action<string> func)
        {
            ActionEvent -= func;
        }

        public void CallAction(string param)
        {
            ActionEvent?.Invoke(param);
        }
    }
}
