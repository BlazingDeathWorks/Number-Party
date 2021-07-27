using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NumberParty
{
    public class ContinueSource : MonoBehaviour
    {
        [SerializeField] GameObject continueButton = null;

        public void ContinueEnable()
        {
            continueButton.SetActive(true);
        }

        public void ContinueDisable()
        {
            continueButton.SetActive(false);
        }
    }
}
