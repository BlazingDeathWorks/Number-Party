using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace NumberParty.PlayUIManager
{
    public class ResultGenerator : MonoBehaviour
    {
        [SerializeField] private Text text = null;

        private void Awake()
        {
            int randomRange = int.Parse(PlayerPrefs.GetString(PlayerPrefsNameManager.playerPrefsRandomRange));
            int randomValue = Random.Range(1, randomRange + 1);
            if (GameManager.instance == null) return;
            string playerCodeName = GameManager.instance.ReturnPlayerCodeName(randomValue);
            if (!string.IsNullOrEmpty(playerCodeName))
            {
                text.text = $"{playerCodeName} Wins\n\nAnswer: {randomValue}";
                return;
            }
            text.text = $"No one Won\n\nAnswer: {randomValue}";
        }

        public void TryAgain()
        {
            GameManager.instance.ClearPlayerDatas();
            SceneTransitioner.ToScene(0);
        }
    }
}
