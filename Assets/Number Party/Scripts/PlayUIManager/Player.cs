using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace NumberParty.PlayUIManager
{
    public class Player : MonoBehaviour
    {
        private InputField inputField = null;

        private void Awake()
        {
            //Initializing
            inputField = GetComponentInChildren<InputField>();

            inputField.characterLimit = GetCharacterLimit();
        }

        //Method to add to submit channel
        public void SubmitPlayerData()
        {
            if (inputField == null || string.IsNullOrEmpty(inputField.text)) return;
            int number = int.Parse(inputField.text);
            if (!string.IsNullOrEmpty(GameManager.instance.ReturnPlayerCodeName(number))) return;
            GameManager.instance.AddPlayerData(new PlayerData($"P{GameManager.instance.playerIndex}", number));
        }

        private int GetCharacterLimit()
        {
            return PlayerPrefs.GetString(PlayerPrefsNameManager.playerPrefsRandomRange).Length;
        }
    }
}
