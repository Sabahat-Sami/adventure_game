using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField] private HealthControl health;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            damage();
        }
    }

    void damage()
    {
        health.playerHealth -= 1;
        health.UpdateHealth();
    }

}
