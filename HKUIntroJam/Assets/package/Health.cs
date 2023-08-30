using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [Range(0, 50)]
    public float health;

    
    [Range(0, 100)]
    public float energy;

    public float penalty;

    public float healthPickup = 10f;
    public float acidDOT = -10f;

    
    public bool isTakingDOT;

    void Update()
    {
        if(health <= 0)
        {
            GameObject.Destroy(this.gameObject);
        }

        if(isTakingDOT)
        {
            ChangeHealth(acidDOT * Time.deltaTime);
        }

        
        
        energy -= 1 * Time.deltaTime;

    }

private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Damaging"))
        {
            isTakingDOT = true;
        }

        if (collision.CompareTag("HealthPickup"))
        {
            ChangeHealth(healthPickup);
        }
    }

private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Damaging"))
        {
            isTakingDOT = false;
        }
    }

    public void ChangeHealth(float value)
    {
        health += value;
        AudioManager.instance.PlaySound("Damage");
    }
}
