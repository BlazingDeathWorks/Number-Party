using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace NumberParty
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager instance = null;

        [SerializeField]
        private ActionChannel onClickChannel = null;
        private ContinueSource continueSource = null;

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
        }

        private void SetContinueSource()
        {
            continueSource = GameObject.Find("Continue Source").GetComponent<ContinueSource>();
        }

        private void SetPlayers()
        {
            players = int.Parse(PlayerPrefs.GetString(PlayerPrefsNameManager.playerPrefsPlayers));
        }

        private void Update()
        {
            if(SceneManager.GetActiveScene().buildIndex == 1)
            {
                if(continueSource == null)
                {
                    SetContinueSource();
                }
            }
        }

        public void ClearPlayerDatas()
        {
            playerDatas = new List<PlayerData>();
            playerIndex = 1;
        }

        public void AddPlayerData(PlayerData playerData)
        {
            playerDatas.Add(playerData);
            SetPlayers();
            if (playerIndex >= players)
            {
                continueSource.ContinueEnable();
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
