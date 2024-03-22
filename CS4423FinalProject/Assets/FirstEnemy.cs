using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstEnemy : MonoBehaviour
{
    [Header("Stats")]

    [SerializeField] float maxMana;
    [SerializeField] private float health;
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
        TestText.singleton.ShowHealth(health);
        defaultMultiplier = healthLossMultiplier;
         RecoverMana(manaRecovery);

        
        //TestText.singleton.ShowHealth(health);

    }

    // Update is called once per frame
    void Update()
    {
        
       // Debug.Log("Health: " + health, this);
       // Debug.Log("Health SO: " + (firstEnemySO.health-1), this);

        //Debug.Log("Update: " + GetInstanceID());
        TestText.singleton.ShowHealth(health);
        shooter.ShootSpells(spell, player.transform.position, 1);
    }

    public void LoseHealth(float loss)
    {
        //Debug.Log("Lose: " + loss);
        
        health -= loss * defaultMultiplier;
        Debug.Log("Health: " + health,this);

        

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

        if (mana <= 0)
            { this.mana = 0; }
        
         //Debug.Log("PlayerSO " + playerSO.mana);
        //Debug.Log("Player " + mana);

    }

    public void RecoverMana(float recover){
        StartCoroutine(RecoverManaRoutine());
        IEnumerator RecoverManaRoutine(){
            while(true){
                yield return new WaitForSeconds(1);
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

    public float GetHealth() {return health;}
    public float GetMana() {return mana;}
}
