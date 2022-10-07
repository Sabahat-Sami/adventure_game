using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
public class PlayerCode : MonoBehaviour
{

    NavMeshAgent _agent;
    Camera mainCam;
    public HealthControl damager;

    
    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        mainCam = Camera.main;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(mainCam.ScreenPointToRay(Input.mousePosition), out hit, 500))
            {
                _agent.SetDestination(hit.point);
            }
            else{
            }
        }
        if(this.gameObject.transform.position.y < -10){
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Tile") && !other.GetComponent<TileScript>().isSafe){
            StartCoroutine(WaitBeforeFalling());
        }
        if (other.CompareTag("Monster"))
        {
            damager.playerHealth -= 1;
        }
        
        }

    IEnumerator WaitBeforeFalling(){
        yield return new WaitForSeconds(1f);
        GetComponent<Rigidbody>().isKinematic = false;
        GetComponent<NavMeshAgent>().enabled = false;
    }
}
