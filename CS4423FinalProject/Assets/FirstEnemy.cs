using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstEnemy : MonoBehaviour
{
    [Header("Stats")]

    [SerializeField] float maxMana;
    float curHealth = 5;
    float mana;
    [SerializeField] float speed;
    [SerializeField] int spell;
    [SerializeField] float jump = 15f;
    [SerializeField] float healthLossMultiplier;
    [SerializeField] float manaRecovery;

    [Header("Necessary Systems")]

    [SerializeField] EnemySO enemySO;
    [SerializeField] EnemyShooter shooter;
    [SerializeField] Player player;


    private float defaultMultiplier;
    //Renderer render;

    
    //[SerializeField]
    // Start is called before the first frame update
    void Start()
    {
        
        if(enemySO != null)
        {
             if(this.tag == "Enemy1")
            {
                this.curHealth = enemySO.firstHealth;
                this.mana = enemySO.firstMana;
                this.maxMana = enemySO.firstMaxMana;
            }  
        
        }

        //Debug.Log("Current Health " + curHealth);

        defaultMultiplier = healthLossMultiplier;

       
        //render = GetComponent<SpriteRenderer>();
        

        Attack();

    }

    // Update is called once per frame
    void Update()
    {
        if ( enemySO != null)
        {
            enemySO.firstHealth = curHealth;
            enemySO.firstMana = mana;
        }

        //Debug.Log("Update Health: " + health, this);
        //TestText.singleton.ShowHealth(health);
    }


    public void LoseHealth(float loss)
    {
        //Debug.Log("Current Health In Lose" + curHealth);
       curHealth -= loss;
    if (curHealth <= 0)
        {
            //this.curHealth = 0;
            Debug.Log("Dead", this);
            //this.enabled=false;
        }
        //Debug.Log("Current Health After Lose" + curHealth);
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
        //Debug.Log("Multiplier: " + defaultMultiplier);
    }

    public void ReduceMana(float cost)
    {
        // Debug.Log("ReduceMana cost: " + cost, this);
        //Debug.Log("ReduceMana mana before: " + this.mana, this);

        SetReducedMana(cost);

        if (mana <= 0)
            { this.mana = 0; }
        //Debug.Log("ReduceMana mana after: " + this.mana, this);


    }

    void RecoverMana(float recover){

            while(mana < maxMana){
                if (curHealth <= 0)
                    break;
                GainMana(recover);
            }

    }

    void GainMana(float gain)
    {
        this.mana += gain;
        if (mana >= maxMana)
            { this.mana = maxMana; }
        //Debug.Log("Recovered Mana:  " + mana);
        //Debug.Log("Player " + mana);

    }

    void Attack()
    {
        //Debug.Log("Current Health " + curHealth);

        //Debug.Log("I'm Working");
        StartCoroutine(AttackRoutine());
        IEnumerator AttackRoutine()
        {
            
            while(true){
                //Debug.Log("Health Attack: "+health,this);
                //Debug.Log("Mana: " + mana, this);
                if (curHealth <= 0)
                    {break;}
                    //Debug.Log("Dead",this);}
                    //Debug.Log("Hit Mana: " + mana, this);
                if(mana > 0)
                {
                    if (curHealth <= 0)
                        {break;}
                    //Debug.Log("Hit Mana: " + mana, this);
                    shooter.ShootSpells(spell, player.transform.position, 1);              
                    //GainMana(recover);
                    yield return new WaitForSeconds(3f);
                    
                    //Debug.Log("Hit Mana: " + mana, this);
                }

                if(mana == 0)
                {
                    if (curHealth <= 0)
                        {break;}
                    //Debug.Log("Hit Mana", this);
                    RecoverMana(manaRecovery);
                    //Debug.Log("Hit Coroutine: " + mana, this);
                    yield return new WaitForSeconds(5f);
                }

                yield return null;
                
            }
        }

                
 
    }

    public float GetHealth() {return curHealth;}
    public float GetMana() {return mana;}
    void SetReducedMana(float mana) {this.mana -= mana;}
    void SetReducedHealth(float health) {
}
}
