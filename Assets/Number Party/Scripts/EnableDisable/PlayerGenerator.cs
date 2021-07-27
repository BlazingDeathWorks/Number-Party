using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NumberParty.EnableDisable
{
    public class PlayerGenerator : MonoBehaviour
    {
        [SerializeField]
        GameObject prefab = null;
        [SerializeField]
        private Transform grid = null;

        int players = 0;

        private void Awake()
        {
            players = int.Parse(PlayerPrefs.GetString(PlayerPrefsNameManager.playerPrefsPlayers));

            InstantiatePlayers();
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
}
