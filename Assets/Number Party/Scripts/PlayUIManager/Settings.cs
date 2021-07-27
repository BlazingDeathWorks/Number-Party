using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace NumberParty.PlayUIManager
{
    public class Settings : MonoBehaviour
    {
        [SerializeField]
        private ActionChannel_String settingsInputField_OnValueChangedChannel = null;
        [SerializeField]
        private ActionChannel enableChannel = null;
        private Transform container = null;
        private InputField inputField = null;

        private void Awake()
        {
            container = transform.GetChild(0);
            inputField = container.GetComponentInChildren<InputField>();

            settingsInputField_OnValueChangedChannel?.AddAction(OnValueChanged);
            enableChannel?.AddAction(ShowCurrentRandomRange);
        }

        private void OnValueChanged(string text)
        {
            PlayerPrefs.SetString(PlayerPrefsNameManager.playerPrefsRandomRange, text);
        }

        private void ShowCurrentRandomRange()
        {
            inputField.text = PlayerPrefs.GetString(PlayerPrefsNameManager.playerPrefsRandomRange);
        }
    }
}
