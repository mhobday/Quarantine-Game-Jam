using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonFunctionality : MonoBehaviour
{
    
    public void PlayGame () {
        SceneManager.LoadScene("MainScene");
    }

    public void Credits () {
        SceneManager.LoadScene("CreditsScene");
    }
}
