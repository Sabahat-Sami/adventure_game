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
            foreach (var entry in PublicVars.items)
            {
                PublicVars.items[entry.Key] = false;
            }

            SceneManager.LoadScene("MainStage");

            health.playerHealth = 3;
        }
    }

}
