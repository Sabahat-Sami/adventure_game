using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetObject : MonoBehaviour
{
    public string pub_name;


    int speed = -25;
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, speed*Time.deltaTime, 0, Space.World) ;      
    }

    private void OnTriggerEnter(Collider other){
        print("Col");
        if(other.CompareTag("Player")){
            Destroy(this.gameObject);
            PublicVars.items[pub_name] = true;
        }
    }
}
