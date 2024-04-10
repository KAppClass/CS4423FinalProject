using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{

    [Header("Stats")]

    [SerializeField] const float damage = 3f;
    [SerializeField] const float cost = 4f;
    [SerializeField] const float speed = 5f;
    [SerializeField] const float damageMultiplier = 4.5f;
    [SerializeField] const float multiplierTime = 6f;

    [SerializeField] HealthSystem healthSystem;

    void OnTriggerEnter2D(Collider2D obj)
    {
        
        if (obj.gameObject.tag == "Enviroment")
        {
            Destroy(this.gameObject);
        }
        if (obj.gameObject.tag == "Enemy1")
        {
            //Debug.Log("This",this);
            
            
            // if(healthSystem == null)
            //     Debug.Log("Health is Null");
            healthSystem.FirstEnemyNegativeHealth(damage, damageMultiplier, multiplierTime);
            Destroy(this.gameObject);
        }
        // if (obj.gameObject.tag == "Player")
        // {
        //     // Debug.Log("Trigger Working", this);
        //     healthSystem.PlayerLoseHealth(damage, damageMultiplier, multiplierTime);
        //     Destroy(this.gameObject);
        // }

    }

    public float GetDamage() {return damage;}
    public float GetCost() {return cost;}
    public float GetSpeed() {return speed;}
    public float GetDamageMultiplier() {return damageMultiplier;}
}
