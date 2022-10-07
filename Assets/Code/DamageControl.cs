using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DamageControl : MonoBehaviour
{
    [SerializeField] private HealthControl health;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {   
            damage();
        }
    }

    public void damage()
    {
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
    }

}
