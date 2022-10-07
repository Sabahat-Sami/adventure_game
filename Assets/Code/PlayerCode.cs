using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class PlayerCode : MonoBehaviour
{

    NavMeshAgent _agent;
    Camera mainCam;
    public HealthControl health;
    public GameObject arrow;

    public string main_lv_name = "MainStage";
    public string gap_lv_name = "GapRoom";
    public string wall_lv_name = "";
    public string maze_lv_name = "FallingMaze";
    public string monster_lv_name = "MonsterRoom";
    public string exit_lv_name = "";

    int arrowForce = 500;
    
    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        mainCam = Camera.main;
        if(PublicVars.items["boots"]){
            _agent.speed = 15f;
        }
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

        }
        else if (Input.GetMouseButton(1) && PublicVars.items["bow"])
        {
            RaycastHit hit;

            if (Physics.Raycast(mainCam.ScreenPointToRay(Input.mousePosition), out hit, 500))
            {
                transform.LookAt(hit.point);
                GameObject newArrow = Instantiate(arrow, transform.position, transform.rotation);
                newArrow.GetComponent<Rigidbody>().AddForce(transform.forward * arrowForce);
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

        if (other.CompareTag("ToMain"))
        {
            SceneManager.LoadScene(main_lv_name);
        }
        if (other.CompareTag("ToMonster"))
        {
            SceneManager.LoadScene(monster_lv_name);
        }
        if (other.CompareTag("ToGap"))
        {
            SceneManager.LoadScene(gap_lv_name);
        }
        if (other.CompareTag("ToWallClose"))
        {
            SceneManager.LoadScene(wall_lv_name);
        }
        if (other.CompareTag("ToMaze"))
        {
            SceneManager.LoadScene(maze_lv_name);
        }
        if (other.CompareTag("ToExit"))
        {
            SceneManager.LoadScene(exit_lv_name);
        }
        if(other.CompareTag("Gap")){
            Rigidbody player = GetComponent<Rigidbody>();
            player.isKinematic = false;
            player.AddForce(-100f, 0f, 0f);

            GetComponent<NavMeshAgent>().enabled = false;
        }


    }

    IEnumerator WaitBeforeFalling(){
        yield return new WaitForSeconds(1f);
        GetComponent<Rigidbody>().isKinematic = false;
        GetComponent<NavMeshAgent>().enabled = false;
    }
}
