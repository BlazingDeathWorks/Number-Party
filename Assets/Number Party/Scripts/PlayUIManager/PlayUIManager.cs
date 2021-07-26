using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

namespace NumberParty
{
    namespace PlayUIManager
    {
        public class PlayUIManager : MonoBehaviour
        {
            [SerializeField]
            private ActionChannel enterButton_OnClickChannel = null;
            [SerializeField]
            private ActionChannel playUI_DisableChannel = null;
            private Transform container = null;
            private InputField inputField = null;
            private const int characterLimit = 1;
            private const string inputLimit = "0123456789";

            private void Awake()
            {
                //Initialize 
                container = transform.GetChild(0);
                inputField = GetComponentInChildren<InputField>();

                //Set container back to false
                container.gameObject.SetActive(false);

                //Customizing inputField
                if (inputField == null) return;
                inputField.characterLimit = characterLimit;
                inputField.onValidateInput += ValidateInput;

                //Add ClearInputField Method to Action Call
                playUI_DisableChannel?.AddAction(ClearInputField);

                //Add OnValueChange Method to Action Call
                enterButton_OnClickChannel?.AddAction(OnValueChange);
            }

            private void ClearInputField()
            {
                //Clears inputField
                inputField.text = string.Empty;
            }

            private char ValidateInput(string text, int charIndex, char addedChar)
            {
                if (inputLimit.Contains(addedChar.ToString()))
                {
                    return addedChar;
                }
                return '\0';
            }

            private void OnValueChange()
            {
                if (string.IsNullOrEmpty(inputField.text)) return;
                StartCoroutine("LetsPlay");
            }

            private IEnumerator LetsPlay()
            {
                const float waitTime = 0.4f;
                PlayerPrefs.SetInt(PlayerPrefsNameManager.playerPrefsPlayers, Int32.Parse(inputField.text));
                yield return new WaitForSecondsRealtime(waitTime);
                SceneTransitioner.NextScene();
            }
        }
    }
}
