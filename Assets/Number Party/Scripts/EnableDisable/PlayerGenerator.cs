using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace NumberParty.EnableDisable
{
    public class PlayerGenerator : MonoBehaviour
    {
        [SerializeField]
        GameObject prefab = null;
        [SerializeField]
        private Transform grid = null;

        [SerializeField]
        private ContinueSource continueButton = null;

        int players = 0;

        private void Start()
        {
            players = int.Parse(PlayerPrefs.GetString(PlayerPrefsNameManager.playerPrefsPlayers));

            continueButton.ContinueDisable();

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
