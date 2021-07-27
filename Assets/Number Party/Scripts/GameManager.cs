using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace NumberParty
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager instance = null;

        [SerializeField]
        private Button continueButton = null;
        [SerializeField]
        private ActionChannel onClickChannel = null;

        public int playerIndex { get; private set; } = 1;
        private int players = 0;

        private List<PlayerData> playerDatas = new List<PlayerData>();

        private void Awake()
        {
            //Singleton
            if(instance != null)
            {
                Destroy(gameObject);
                return;
            }
            instance = this;
            DontDestroyOnLoad(gameObject);

            onClickChannel?.AddAction(SceneTransitioner.NextScene);

            if (continueButton == null) return;
            continueButton.gameObject.SetActive(false);

            players = int.Parse(PlayerPrefs.GetString(PlayerPrefsNameManager.playerPrefsPlayers));
        }

        public void AddPlayerData(PlayerData playerData)
        {
            playerDatas.Add(playerData);
            if (playerIndex >= players)
            {
                if (continueButton == null) return;
                continueButton.gameObject.SetActive(true);
                return;
            }
            playerIndex++;
        }

        public string ReturnPlayerCodeName(int randomValue)
        {
            if (playerDatas == null) return null;
            foreach(PlayerData playerData in playerDatas)
            {
                if (playerData.number != randomValue) continue;
                return playerData.playerCodeName;
            }
            return null;
        }
    }

    public class PlayerData
    {
        public readonly string playerCodeName = "";
        public readonly int number = 0;

        public PlayerData(string playerCodeName, int number)
        {
            this.playerCodeName = playerCodeName;
            this.number = number;
        }
    }
}
