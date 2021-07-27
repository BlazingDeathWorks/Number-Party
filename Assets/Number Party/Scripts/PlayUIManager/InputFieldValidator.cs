using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace NumberParty.PlayUIManager
{
    public class InputFieldValidator : MonoBehaviour
    {
        private InputField inputField = null;
        public int characterLimit = 1;
        private Transform container = null;
        [SerializeField]
        private string inputLimit = "";

        private void Awake()
        {
            container = transform.GetChild(0);
            inputField = container.GetComponentInChildren<InputField>();

            //Customizing inputField
            if (inputField == null) return;
            inputField.characterLimit = characterLimit;
            inputField.onValidateInput += ValidateInput;
        }

        private char ValidateInput(string text, int charIndex, char addedChar)
        {
            if (inputLimit.Contains(addedChar.ToString()))
            {
                return addedChar;
            }
            return '\0';
        }
    }
}
