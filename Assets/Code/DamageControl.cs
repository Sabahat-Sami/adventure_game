using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    }

}
