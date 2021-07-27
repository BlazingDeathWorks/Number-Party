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
        GameObject prefab = null;
        [SerializeField]
        private Transform grid = null;

        [SerializeField]
        private Button continueButton = null;

        public int playerIndex { get; private set; } = 1;
        int players = 0;

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

            if (continueButton == null) return;
            continueButton.gameObject.SetActive(false);

            players = int.Parse(PlayerPrefs.GetString(PlayerPrefsNameManager.playerPrefsPlayers));

            InstantiatePlayers();
        }

        public void AddPlayerData(PlayerData playerData)
        {
            playerDatas.Add(playerData);
            if(playerIndex >= players)
            {
                if (continueButton == null) return;
                //continueButton.gameObject.
                return;
            }
            playerIndex++;
        }

        private void InstantiatePlayers()
        {
            if (prefab == null || grid == null) return;
            for (int i = 0; i < players; i++)
            {
                GameObject prefabInstance = Instantiate(prefab, transform.position, Quaternion.identity);
                prefabInstance.transform.SetParent(grid);
            }
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
