using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace NumberParty.PlayUIManager
{
    public class Player : MonoBehaviour
    {
        [SerializeField]
        private ActionChannel submitButton_OnClickChannel = null;
        private InputField inputField = null;

        private void Awake()
        {
            //Initializing
            inputField = GetComponentInChildren<InputField>();

            inputField.characterLimit = GetCharacterLimit();

            //Channel Adding
            submitButton_OnClickChannel?.AddAction(SubmitPlayerData);
        }

        //Method to add to submit channel
        private void SubmitPlayerData()
        {
            if (inputField == null || string.IsNullOrEmpty(inputField.text)) return;
            GameManager.instance.AddPlayerData(new PlayerData($"Player{GameManager.instance.playerIndex}", int.Parse(inputField.text)));
        }

        private int GetCharacterLimit()
        {
            return PlayerPrefs.GetString(PlayerPrefsNameManager.playerPrefsRandomRange).Length;
        }
    }
}
