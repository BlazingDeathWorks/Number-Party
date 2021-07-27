using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace NumberParty
{
    public static class SceneTransitioner
    {
        public static void NextScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        public static void ToScene(int index)
        {
            SceneManager.LoadScene(index);
        }
    }
}
