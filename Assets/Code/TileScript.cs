using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileScript : MonoBehaviour
{   
    public bool isSafe;
    void Start()
    {   
        print(PublicVars.hasGoggles);
        if(PublicVars.hasGoggles && !isSafe){
            print(PublicVars.hasGoggles);
            GetComponent<Rigidbody>().isKinematic = false;
        }
    }
    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player")){
            if(!isSafe){
                StartCoroutine(WaitBeforeFalling());
                GetComponent<Rigidbody>().isKinematic = false;
            }
        }
    }
    IEnumerator WaitBeforeFalling(){
        yield return new WaitForSeconds(2f);
    }

}
