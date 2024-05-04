using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonPlantBall : MonoBehaviour
{

    [Header("Stats")]

    [SerializeField] const float damage = 3f;
    [SerializeField] const float cost = 1f;
    [SerializeField] const float speed = 5f;

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
        
        if (obj.gameObject.tag == "Player")
        {
            // Debug.Log("Trigger Working", this);
            healthSystem.PlayerLoseHealth(damage);
            Destroy(this.gameObject);
        }

    }

    public float GetDamage() {return damage;}
    public float GetCost() {return cost;}
    public float GetSpeed() {return speed;}
}
