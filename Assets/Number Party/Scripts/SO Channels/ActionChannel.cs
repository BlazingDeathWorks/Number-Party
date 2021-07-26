using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace NumberParty
{
    [CreateAssetMenu(fileName = "NewActionChannel", menuName = "Channels/ActionChannel")]
    public class ActionChannel : ScriptableObject
    {
        private event Action ActionEvent;

        public void AddAction(Action func)
        {
            ActionEvent += func;
        }

        public void RemoveAction(Action func)
        {
            ActionEvent -= func;
        }

        public void CallAction()
        {
            ActionEvent?.Invoke();
        }
    }
}
