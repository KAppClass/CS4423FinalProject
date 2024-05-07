using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonDarkBall : MonoBehaviour
{
    [Header("Manager")]
    public DemonDarkBallManager manager;

    [Header("Stats")]

    [SerializeField] const float damage = 0.5f;
    [SerializeField] const float speed = 3f;

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
            manager.AddBall(this);
        }
        
        if (obj.gameObject.tag == "Player")
        {
            // Debug.Log("Trigger Working", this);
            healthSystem.PlayerLoseHealth(damage);
            manager.AddBall(this);
        }

    }

    public float GetDamage() {return damage;}
    public float GetSpeed() {return speed;}
}
