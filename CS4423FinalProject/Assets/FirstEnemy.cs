using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstEnemy : MonoBehaviour
{
    [Header("Stats")]

    [SerializeField] float maxHealth = 20f;
    [SerializeField] float maxMana = 20f;
    [SerializeField] float health;
    [SerializeField] float mana = 20f;
    [SerializeField] float speed;
    [SerializeField] int spell;
    [SerializeField] float jump = 15f;
    [SerializeField] float healthLossMultiplier = 1f;
    [SerializeField] float manaRecovery;

    [SerializeField] FirstEnemySO firstEnemySO;

    private float defaultMultiplier;
    
    //[SerializeField]
    // Start is called before the first frame update
    void Start()
    {
        if (firstEnemySO != null)
        {

            maxHealth = firstEnemySO.maxHealth;
            health = firstEnemySO.maxHealth;

        }
        //health = maxHealth;
        defaultMultiplier = healthLossMultiplier;
        TestText.singleton.ShowHealth(health);

    }

    // Update is called once per frame
    void Update()
    {
        if (firstEnemySO != null)
        {
            firstEnemySO.health = health;

        }
        
    }

    public void LoseHealth(float loss)
    {

        Debug.Log("Health: " + health);
        health -= loss * defaultMultiplier;
        Debug.Log("Health: " + health);
        TestText.singleton.ShowHealth(health);

        if (health <= 0)
        {
            TestText.singleton.ShowHealth(-100);
        }

        //Debug.Log("Current Health: " + firstEnemySO.health);
        // float afterHealth = health - (loss * defaultMultiplier);
        // Debug.Log("Loss: " + afterHealth);
        // if (afterHealth <= 0)
        //     { //this.health = afterHealth; 
        //     Destroy(this);}
        // else
        // {
        //     health = afterHealth;
        //     Debug.Log("Health: " + health);
        //     Debug.Log("This",this);
        //     TestText.singleton.ShowHealth(health);
            
        // }
    }

    public void TempChangeMultiplier(float multiplier, float time)
    {
        
        defaultMultiplier = multiplier;
        
        // float timer = 0;
        // while(timer < time)
        // {
        //     timer+=Time.deltaTime;
        // }
        // defaultMultiplier= healthLossMultiplier;
        // Debug.Log("Enemy multiplier: " + defaultMultiplier);
    }

    public float GetHealth() {return health;}
}
