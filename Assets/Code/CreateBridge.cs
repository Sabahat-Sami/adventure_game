using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreateBridge : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if(PublicVars.items["bridge"] == false){
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other){
        print("Found");
        if(other.CompareTag("Player")){
            print("Found");
            SceneManager.LoadScene("GapRoomBridge");
        }
    }
}
