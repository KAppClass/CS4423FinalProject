using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] PlayerSO playerSO;

    [SerializeField] float maxHealth;
    [SerializeField] float maxMana;
    [SerializeField] float health;
    [SerializeField] float mana;
    [SerializeField] float speed;
    [SerializeField] int spell;

    [SerializeField] float jump = 15f;
    [SerializeField] float healthLossMultiplier = 1f;
    [SerializeField] float manaRecovery;

    [Header("Physics")]

    [SerializeField] LayerMask ground;
    [SerializeField] float jumpOffset = -0.5f;
    [SerializeField] float jumpRadius = 0.25f;

    Rigidbody2D rigid;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        
        if (playerSO != null)
        {
            maxHealth = playerSO.maxHealth;
            maxMana = playerSO.maxMana;
            health = playerSO.health;
            mana = playerSO.mana;
            speed = playerSO.speed;
            jump = playerSO.jump;
            healthLossMultiplier = playerSO.healthLossMultiplier;
            spell = playerSO.spell;
            manaRecovery = playerSO.manaRecovery;
        }

        

        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerSO != null)
        {
            playerSO.health = health;
            playerSO.mana = mana;
            playerSO.speed = speed;
            playerSO.jump = jump;
            playerSO.healthLossMultiplier = healthLossMultiplier;
        }

        Debug.Log("PlayerSO " + playerSO.mana);
        Debug.Log("Player " + mana);


    }

    public void LoseHealth(float loss)
    {
        float afterHealth = this.health - (loss * healthLossMultiplier);
        if (afterHealth <= 0)
            { this.health = 0; }
        else
        {
            this.health = afterHealth;
        }
    }

    public void GainHealth(float gain)
    {
        float afterHealth = this.health + gain;
        if (afterHealth >= maxHealth)
            { this.health = maxHealth; }
        else
        {
            this.health = afterHealth;
        }
    }

    public void ReduceMana(float cost)
    {
        float afterMana = this.mana - cost;

        if (afterMana <= 0)
            { this.mana = 0; }
        else
        {
            this.mana = afterMana;
        }
    }

    public void RecoverMana(float recover){
        StartCoroutine(RecoverManaRoutine());
        IEnumerator RecoverManaRoutine(){
            while(true){
                yield return new WaitForSeconds(0.0000001f);
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
    }

    public void ChangeMaxHealth(float max)
    {
        maxHealth = max;
    }

    public Rigidbody2D GetRigid() { return this.rigid; }
    public float GetSpeed() { return this.speed; }
    public float GetJump() { return this.jump; }
    public float GetJumpOffset() { return this.jumpOffset; }
    public float GetJumpRadius() { return this.jumpRadius; }
    public LayerMask GetGroundLayer() { return this.ground; }

}
