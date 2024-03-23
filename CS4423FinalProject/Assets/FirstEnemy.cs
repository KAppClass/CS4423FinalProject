using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstEnemy : MonoBehaviour
{
    [Header("Stats")]

    [SerializeField] float maxMana;
    [SerializeField] float maxHealth;
    [SerializeField] private float health;
    [SerializeField] private float mana;
    [SerializeField] float speed;
    [SerializeField] int spell;
    [SerializeField] float jump = 15f;
    [SerializeField] float healthLossMultiplier = 1f;
    [SerializeField] float manaRecovery;

    [Header("Necessary Systems")]

    [SerializeField] ShootSpell shooter;
    [SerializeField] Player player;
    [SerializeField] TestText test;


    private float defaultMultiplier;
    //Renderer render;

    
    //[SerializeField]
    // Start is called before the first frame update
    void Start()
    {
        

        if(mana != maxMana)
            mana = maxMana;

        defaultMultiplier = healthLossMultiplier;
        //render = GetComponent<SpriteRenderer>();
        Debug.Log("Hello");


        Attack();

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(health,this);

    }

    public void LoseHealth(float loss)
    {
        
        health -= loss * defaultMultiplier;

         if (health <= 0)
        {
            Debug.Log("Dead", this);
            //this.enabled=false;
        }
        
    }

    public void TempChangeMultiplier(float multiplier, float time)
    {
        
        defaultMultiplier = multiplier;
        
        float timer = 0;
        while(timer < time)
        {
            timer+=Time.deltaTime;
            //Debug.Log(""+defaultMultiplier + " Time: " + timer);
        }
        defaultMultiplier= healthLossMultiplier;
    }

    public void ReduceMana(float cost)
    {
        // Debug.Log("ReduceMana cost: " + cost, this);
        // Debug.Log("ReduceMana mana before: " + mana, this);

        this.mana -= cost;

        if (mana <= 0)
            { this.mana = 0; }
        //Debug.Log("ReduceMana mana after: " + cost, this);


    }

    public void RecoverMana(float recover){

            while(mana < maxMana){
                GainMana(recover);
            }

    }

    public void GainMana(float gain)
    {
        this.mana += gain;
        if (mana >= maxMana)
            { this.mana = maxMana; }
        Debug.Log("Recovered Mana:  " + mana);
        //Debug.Log("Player " + mana);

    }

    void Attack()
    {
        Debug.Log("I'm Working");
        StartCoroutine(AttackRoutine());
        IEnumerator AttackRoutine()
        {
            
            while(true){
                Debug.Log("Mana: " + mana, this);
                // if (health <= 0)
                //     break;
                    //Debug.Log("Dead",this);}
                    //Debug.Log("Hit Mana: " + mana, this);
                if(mana > 0)
                {
                    
                    Debug.Log("Hit Mana: " + mana, this);
                    shooter.ShootSpells(spell, player.transform.position, 1);              
                    //GainMana(recover);
                    yield return new WaitForSeconds(3f);
                    
                    //Debug.Log("Hit Mana: " + mana, this);
                }

                if(mana == 0)
                {
                    //Debug.Log("Hit Mana", this);
                    RecoverMana(manaRecovery);
                    Debug.Log("Hit Coroutine: " + mana, this);
                    yield return new WaitForSeconds(5f);
                }

                yield return null;
                
            }
        }

                
 
    }

    public float GetHealth() {return health;}
    public float GetMana() {
        
        return mana;}
}
