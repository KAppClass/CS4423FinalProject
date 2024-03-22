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


    private float defaultMultiplier;
    
    //[SerializeField]
    // Start is called before the first frame update
    void Start()
    {
        //TestText.singleton.ShowHealth(health);
        defaultMultiplier = healthLossMultiplier;
        //mana = maxMana;
        //health = maxHealth;
        //  RecoverMana(manaRecovery);

        Attack(manaRecovery);
        //TestText.singleton.ShowHealth(health);
        Debug.Log(health,this);

    }

    // Update is called once per frame
    void Update()
    {
        
       // Debug.Log("Health: " + health, this);
       // Debug.Log("Health SO: " + (firstEnemySO.health-1), this);
        
        //Debug.Log("Update: " + GetInstanceID());
        TestText.singleton.ShowHealth(mana);
        //shooter.ShootSpells(spell, player.transform.position, 1);
    }

    public void LoseHealth(float loss)
    {
        //Debug.Log("Lose: " + loss);
        
        health -= loss * defaultMultiplier;
        Debug.Log("Health: " + health,this);
        TestText.singleton.ShowHealth(health);


         if (health <= 0)
        {
            health = 0;
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
        
        this.mana -= cost;
        //Debug.Log("Hit Mana: " + mana, this);

        if (mana <= 0)
            { this.mana = 0; }
        
         //Debug.Log("PlayerSO " + playerSO.mana);
        //Debug.Log("Player " + mana);

    }

    public void RecoverMana(float recover){

            while(mana > maxMana){
                Debug.Log("Hello " + mana, this);
                GainMana(recover);
            }

    }

    public void GainMana(float gain)
    {
        float afterMana = this.mana + gain;
        if (afterMana >= maxMana)
            { this.mana = maxMana; }
        else
        {
            this.mana = afterMana;
        }
        Debug.Log("Recovered Mana:  " + mana);
        //Debug.Log("Player " + mana);

    }

    void Attack(float recover)
    {

        StartCoroutine(AttackRoutine());
        IEnumerator AttackRoutine()
        {
            while(true){
                Debug.Log("Mana: " + mana, this);
                if (health <= 0)
                    break;
                    //Debug.Log("Hit Mana: " + mana, this);
                if(mana > 0)
                {
                    if (health <= 0)
                    break;
                    //Debug.Log("Hit Mana: " + mana, this);
                    shooter.ShootSpells(spell, player.transform.position, 1);              
                    //GainMana(recover);
                    yield return new WaitForSeconds(5);
                    if (health <= 0)
                    break;
                    //Debug.Log("Hit Mana: " + mana, this);
                }

                else
                {
                    Debug.Log("Hit Mana", this);
                    RecoverMana(recover);
                    //Debug.Log("Hit Mana: " + mana, this);
                }

                yield return null;
                
            }
        }

                
 
    }

    public float GetHealth() {return health;}
    public float GetMana() {
        
        return mana;}
}
