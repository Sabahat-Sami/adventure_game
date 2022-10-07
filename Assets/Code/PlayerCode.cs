using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
public class PlayerCode : MonoBehaviour
{

    NavMeshAgent _agent;
    Camera mainCam;

    public bool haveBoots = false;
    public bool haveGoggles = false;
    public bool haveBridge = false;
    public bool haveKey = false;
    public bool haveBow = false;
    
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

        switch (other.tag)
        {
            case "Boots":
                Destroy(other.gameObject);
                haveBoots = true;
                break;

            case "Bow":
                Destroy(other.gameObject);
                haveBow = true;
                break;

            case "Goggles":
                Destroy(other.gameObject);
                haveGoggles = true;
                break;

            case "Bridge":
                Destroy(other.gameObject);
                haveBridge = true;
                break;

            case "Key":
                Destroy(other.gameObject);
                haveKey = true;
                break;

            case "Monster":
                break;
            default:
                break;
        }


    }
    IEnumerator WaitBeforeFalling(){
        yield return new WaitForSeconds(1f);
        GetComponent<Rigidbody>().isKinematic = false;
        GetComponent<NavMeshAgent>().enabled = false;
    }
}
