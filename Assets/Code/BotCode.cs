using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class BotCode : MonoBehaviour
{
    GameObject player;
    NavMeshAgent _agent;
    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(LookForPlayer());
    }

    // Update is called once per frame
    IEnumerator LookForPlayer(){
        while(true){
            yield return new WaitForSeconds(.5f);
            _agent.SetDestination(player.transform.position);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Arrow"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
