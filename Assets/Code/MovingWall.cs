using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovingWall : MonoBehaviour
{
    Rigidbody _rb;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {   
        if(PublicVars.items["goggles"]){
            _rb.velocity = new Vector3(0, 0, 0);
        }
        else{
            if(transform.eulerAngles.z == 90f){
                _rb.velocity = new Vector3(-2, 0, 0);
            }
            else{
                _rb.velocity = new Vector3(2, 0, 0);
            }
        }

    }
    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player")){
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
