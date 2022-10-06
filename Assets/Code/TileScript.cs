using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileScript : MonoBehaviour
{   
    public bool isSafe;
    void Start()
    {   
        if(PublicVars.items["goggles"] && !isSafe){
            GetComponent<Rigidbody>().isKinematic = false;
        }
    }
    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player")){
            if(!isSafe){
                StartCoroutine(WaitBeforeFalling());
            }
        }
    }
    IEnumerator WaitBeforeFalling(){
        yield return new WaitForSeconds(1f);
        GetComponent<Rigidbody>().isKinematic = false;
    }

}
