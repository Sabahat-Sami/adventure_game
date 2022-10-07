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
    public string wall_lv_name = "ClosingWalls";
    public string maze_lv_name = "FallingMaze";
    public string monster_lv_name = "MonsterRoom";
    int arrowForce = 500;
    bool arrowSpawning = false;
    public float arrowDelay = 0.05f;
    public string exit_lv_name = "FinalRoom";

    
    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        mainCam = Camera.main;
        if(PublicVars.items["boots"]){
            _agent.speed = 15f;
            _agent.acceleration = 60f;
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
        else if (Input.GetMouseButton(1) && PublicVars.items["bow"] && !arrowSpawning)
        {
            RaycastHit hit;

            if (Physics.Raycast(mainCam.ScreenPointToRay(Input.mousePosition), out hit, 500))
            {
                transform.LookAt(hit.point);
                StartCoroutine(ArrowWait());
            }

        }
        if(this.gameObject.transform.position.y < -10){
            PublicVars.playerHealth -= 1;
            health.UpdateHealth();
            if(PublicVars.playerHealth == 0) // reset game
                {   
                List<string> keyList = new List<string>(PublicVars.items.Keys);
                for(int i = 0; i < keyList.Count; i++)
                {
                    PublicVars.items[keyList[i]] = false;
                }
                SceneManager.LoadScene("MainStage");
                PublicVars.playerHealth = 3;
                }
            else{
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
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
            print("HITTTT");
            print(wall_lv_name);
            SceneManager.LoadScene(wall_lv_name);
        }
        if (other.CompareTag("ToMaze"))
        {
            SceneManager.LoadScene(maze_lv_name);
        }
        if (other.CompareTag("ToExit"))
        {
            if(PublicVars.items["key"]){
                SceneManager.LoadScene(exit_lv_name);
            }
        }
        if(other.CompareTag("Gap")){
            Rigidbody player = GetComponent<Rigidbody>();
            player.isKinematic = false;
            player.AddForce(-50f, 0f, 0f);

            GetComponent<NavMeshAgent>().enabled = false;
        }


    }

    IEnumerator WaitBeforeFalling(){
        yield return new WaitForSeconds(.3f);
        GetComponent<Rigidbody>().isKinematic = false;
        GetComponent<NavMeshAgent>().enabled = false;
    }

    IEnumerator ArrowWait()
    {
        arrowSpawning = true;
        yield return new WaitForSeconds(arrowDelay);
        GameObject newArrow = Instantiate(arrow, transform.position, transform.rotation);
        newArrow.GetComponent<Rigidbody>().AddForce(transform.forward * arrowForce);
        arrowSpawning = false;
    }

}
