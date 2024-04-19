using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBall : MonoBehaviour
{

    [Header("Stats")]

    [SerializeField] const float damage = 2f;
    [SerializeField] const float cost = 1f;
    [SerializeField] const float speed = 3f;
    [SerializeField] const float damageMultiplier = 5f;
    [SerializeField] const float multiplierTime = 4f;

    [SerializeField] HealthSystem healthSystem;

    void OnTriggerEnter2D(Collider2D obj)
    {
        
        if (obj.gameObject.tag == "Enviroment")
        {
            Destroy(this.gameObject);
        }
        if (obj.gameObject.tag == "Enemy1" || obj.gameObject.tag == "Enemy2")
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
