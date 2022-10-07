using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreen : MonoBehaviour
{
    public void BackToLobby(){
        PublicVars.items["goggles"] = false;
        PublicVars.items["boots"] = false;
        PublicVars.items["chalice"] = false;
        PublicVars.items["bow"] = false;
        PublicVars.items["key"] = false;
        PublicVars.items["bridge"] = false;
        PublicVars.playerHealth = 3;
        SceneManager.LoadScene("StartMenu");
    }

    public void QuitGame(){
        Application.Quit();
    }
}