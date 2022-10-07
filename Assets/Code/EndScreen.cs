using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreen : MonoBehaviour
{
    public void BackToLobby(){
        SceneManager.LoadScene("StartMenu");
    }

    public void QuitGame(){
        Application.Quit();
    }
}