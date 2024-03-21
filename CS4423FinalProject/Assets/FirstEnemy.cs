using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstEnemy : MonoBehaviour
{
    [Header("Stats")]

    [SerializeField] float maxHealth = 20f;
    [SerializeField] float maxMana = 20f;
    [SerializeField] private float health;
    [SerializeField] static float mana = 20f;
    [SerializeField] float speed;
    [SerializeField] int spell;
    [SerializeField] float jump = 15f;
    [SerializeField] float healthLossMultiplier = 1f;
    [SerializeField] float manaRecovery;

    [SerializeField] FirstEnemySO firstEnemySO;

    private float currHealth;
    private float defaultMultiplier;
    
    //[SerializeField]
    // Start is called before the first frame update
    void Start()
    {
        // if (firstEnemySO != null)
        // {

        //     health = firstEnemySO.health;

        // }
        // defaultMultiplier = healthLossMultiplier;
        // TestText.singleton.ShowHealth(health);

        currHealth = health;
        Debug.Log(currHealth);

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
        //Debug.Log("Current Health: " + firstEnemySO.health);
        float afterHealth = currHealth - (loss * defaultMultiplier);
        Debug.Log("Loss: " + afterHealth);
        if (afterHealth <= 0)
            { //this.health = afterHealth; 
            Destroy(this);}
        else
        {
            currHealth = afterHealth;
            Debug.Log("Health: " + currHealth);
            Debug.Log("This",this);
            TestText.singleton.ShowHealth(health);
            
        }
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
