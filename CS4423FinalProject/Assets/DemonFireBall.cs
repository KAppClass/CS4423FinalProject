using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonFireBall : MonoBehaviour
{

    [Header("Stats")]

    [SerializeField] float damage = 2f;
    [SerializeField] float cost = 2f;
    [SerializeField] float speed = 5f;
    [SerializeField] float damageMultiplier = 2f;
    [SerializeField] float multiplierTime = 4f;

    [SerializeField] HealthSystem healthSystem;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D obj)
    {
        
        if (obj.gameObject.tag == "Enviroment")
        {
            Destroy(this.gameObject);
        }
        // if (obj.gameObject.tag == "Enemy1")
        // {
        //     //Debug.Log("This",this);
            
            
        //     // if(healthSystem == null)
        //     //     Debug.Log("Health is Null");
        //     healthSystem.FirstEnemyNegativeHealth(damage, damageMultiplier, multiplierTime);
        //     Destroy(this.gameObject);
        // }
        if (obj.gameObject.tag == "Player")
        {
            // Debug.Log("Trigger Working", this);
            healthSystem.PlayerLoseHealth(damage, damageMultiplier, multiplierTime);
            Destroy(this.gameObject);
        }

    }

    public float GetDamage() {return damage;}
    public float GetCost() {return cost;}
    public float GetSpeed() {return speed;}
    public float GetDamageMultiplier() {return damageMultiplier;}
}
