using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    void EndGame ()
    {

    }
    
    string scene = "TitleScene";
    SceneManager.LoadScene(scene);
    //have to go into build settings and build the scenes

    //title
    //climbing -> spawn enemies, after some amount of time 
    //boss fight (change background)
    //credits
}
