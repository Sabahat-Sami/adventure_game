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
        health.playerHealth -= 1;
        health.UpdateHealth();

        if(health.playerHealth == 0) // reset game
        {
            foreach(var (key, value) in PublicVars.items)
            {
                PublicVars.items[key] = false;
            }

            SceneManager.LoadScene("MainStage");

            health.playerHealth = 3;
        }
    }

}
