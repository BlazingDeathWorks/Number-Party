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

            private void Awake()
            {
                //Initialize
                container = transform.GetChild(0);
                inputField = container.GetComponentInChildren<InputField>();

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

            private void OnValueChange()
            {
                if (string.IsNullOrEmpty(inputField.text)) return;
                StartCoroutine("LetsPlay");
            }

            private IEnumerator LetsPlay()
            {
                const float waitTime = 0.4f;
                PlayerPrefs.SetString(PlayerPrefsNameManager.playerPrefsPlayers, inputField.text);
                yield return new WaitForSecondsRealtime(waitTime);
                SceneTransitioner.NextScene();
            }
        }
    }
}
