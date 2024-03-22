using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstEnemy : MonoBehaviour
{
    [Header("Stats")]

    [SerializeField] float maxMana;
    [SerializeField] float maxHealth;
     private float health;
    private float mana;
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
        mana = maxMana;
        health = maxHealth;
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
        shooter.ShootSpells(spell, player.transform.position, 1);
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
        Debug.Log("Hit Mana: " + mana, this);

        if (mana <= 0)
            { this.mana = 0; }
        
         //Debug.Log("PlayerSO " + playerSO.mana);
        //Debug.Log("Player " + mana);

    }

    public void RecoverMana(float recover){
        StartCoroutine(RecoverManaRoutine());
        IEnumerator RecoverManaRoutine(){
            while(mana > maxMana){
                yield return new WaitForSeconds(0.5f);
                GainMana(recover);
            }
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
        //Debug.Log("PlayerSO " + playerSO.mana);
        //Debug.Log("Player " + mana);

    }

    void Attack(float recover)
    {
        while(health > 0){
            StartCoroutine(AttackRoutine());
            IEnumerator AttackRoutine(){
                    while (mana > 0)
                    {
                        //Debug.Log("Hit Mana: " + mana, this);
                        shooter.ShootSpells(spell, player.transform.position, 1);
                        yield return new WaitForSeconds(5f);
                    }
                    
                    RecoverMana(recover);
                    yield return null;
                }
        }


        
    }

    public float GetHealth() {return health;}
    public float GetMana() {
        
        return mana;}
}
