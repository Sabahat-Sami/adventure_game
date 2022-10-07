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

    public string main_lv_name = "MainStage";
    public string gap_lv_name = "GapRoom";
    public string wall_lv_name = "";
    public string maze_lv_name = "FallingMaze";
    public string monster_lv_name = "MonsterRoom";
    public string exit_lv_name = "";
    
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


    }

    IEnumerator WaitBeforeFalling(){
        yield return new WaitForSeconds(1f);
        GetComponent<Rigidbody>().isKinematic = false;
        GetComponent<NavMeshAgent>().enabled = false;
    }
}
