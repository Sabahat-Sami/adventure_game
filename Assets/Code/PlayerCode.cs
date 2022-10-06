using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerCode : MonoBehaviour
{

    NavMeshAgent _agent;
    Camera mainCam;

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
                print(hit);
                _agent.SetDestination(hit.point);
            }
            else{
                print("None");
            }
        }
    }
}
