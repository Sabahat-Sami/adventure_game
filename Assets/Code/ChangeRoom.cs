using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeRoom : MonoBehaviour
{
    public string levelName;

    private void OnTriggerEnter(Collider other) {
        print("Done");
        if(other.CompareTag("Player")){
            print("Done");
            SceneManager.LoadScene(levelName);
        }
    }
}