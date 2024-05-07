using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Stats")]

    [SerializeField] float health;
    [SerializeField] float maxMana;
    [SerializeField] float mana;
    [SerializeField] int spell;
    [SerializeField] float healthLossMultiplier;
    [SerializeField] float manaRecovery;
    [SerializeField] float waitTime;
    [SerializeField] float shootTime;

    [Header("Necessary Systems")]

    [SerializeField] EnemySO enemySO;
    [SerializeField] EnemyShooter shooter;
    [SerializeField] Player player;
    [SerializeField] DoorManager door;


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
                this.health = enemySO.firstMaxHealth;
                this.mana = enemySO.firstMaxMana;
                this.manaRecovery = enemySO.firstManaRecovery;
                this.shootTime = enemySO.firstShootTime;
                this.spell = 2;
            }  

            if(this.tag == "Enemy2")
            {
                this.health = enemySO.secondMaxHealth;
                this.mana = enemySO.secondMaxMana;
                this.manaRecovery = enemySO.secondManaRecovery;
                this.shootTime = enemySO.secondShootTime;
                this.spell = 0;
            }

            if(this.tag == "Enemy3")
            {
                this.health = enemySO.thirdMaxHealth;
                this.mana = enemySO.thirdMaxMana;
                this.manaRecovery = enemySO.thirdManaRecovery;
                this.shootTime = enemySO.thirdShootTime;
                this.spell = 1;
            }  

            this.maxMana = this.mana;

            if(enemySO.hard)
            {
                health *= 2;
                maxMana *= 2;
                mana *= 2;
                manaRecovery /= 2;
                shootTime /=2;

                if(this.tag == "Enemy1")
                {
                    enemySO.firstSpeed /= 2;
                }  

                if(this.tag == "Enemy2")
                {
                    enemySO.secondSpeed /= 2;
                }
            }
        
        }

        
        defaultMultiplier = healthLossMultiplier;
        

    }

    // Update is called once per frame
    void Update()
    {
        if ( enemySO != null)
        {
            enemySO.firstHealth = health;
            enemySO.firstMana = mana;
        }

        if ( enemySO != null)
        {
            enemySO.secondHealth = health;
            enemySO.secondMana = mana;
        }

        if ( enemySO != null)
        {
            enemySO.thirdHealth = health;
            enemySO.thirdMana = mana;
        }

        Debug.Log("Current Health " + health);

        //Debug.Log("Shoot Speed" + shootTime);

    }


    public void LoseHealth(float loss)
    {
        this.health -= loss * defaultMultiplier;
        if (this.health <= 0)
        { 
            if(this.tag == "Enemy1")
            {
                enemySO.firstHealth = 0;
            }  

            if(this.tag == "Enemy2")
            {
                enemySO.secondHealth = 0;
            }

            if(this.tag == "Enemy2")
            {
                enemySO.thirdHealth = 0;
            }

            door.OpenExit();
            gameObject.SetActive(false);
        }
    }

 
    public void ChangeMultiplier(float multiplier)
    {
        defaultMultiplier = multiplier;
    }

    public void ChangeSpeed(float speed)
    {
        this.shootTime = this.shootTime*speed;
        this.manaRecovery = this.manaRecovery*speed;

        if(this.tag == "Enemy1")
            {
                enemySO.firstSpeed = enemySO.firstSpeed*speed;
            }  

        if(this.tag == "Enemy2")
        {
            enemySO.secondSpeed = enemySO.secondSpeed*speed;
        }
        
    }

    public void ReduceMana(float cost)
    {
        SetReducedMana(cost);

        if (mana <= 0)
            { this.mana = 0; }
    }

    void RecoverMana(){

        mana = maxMana;

    }

    public void Attack()
    {
        //Debug.Log("Current Health " + health);

        //Debug.Log("I'm Working");
        StartCoroutine(AttackRoutine());
        IEnumerator AttackRoutine()
        {
            
            while(true){
                
                if(mana > 0)
                {
                    shooter.ShootSpells(spell, player.transform.position, 1);              
                    yield return new WaitForSeconds(shootTime);
                }

                if(mana == 0)
                {
                    RecoverMana();
                    yield return new WaitForSeconds(manaRecovery);
                }

                yield return null;
                
            }
        }

                
 
    }

    public float GetHealth() {return health;}
    public float GetMana() {return mana;}
    void SetReducedMana(float mana) {this.mana -= mana;}
    void SetReducedHealth(float health) {this.health -= health;}
}
