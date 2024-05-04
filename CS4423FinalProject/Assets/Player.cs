using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    [SerializeField] PlayerSO playerSO;

    [Header("Stats")]

    [SerializeField] float maxHealth;
    [SerializeField] float maxMana;
    [SerializeField] float shield;
    [SerializeField] float health;
    [SerializeField] float mana;
    [SerializeField] float speed;
    [SerializeField] int shootSpell;
    [SerializeField] float jump = 15f;
    [SerializeField] float manaRecovery;

    [Header("Physics")]

    [SerializeField] LayerMask ground;
    [SerializeField] float jumpOffset = -0.5f;
    [SerializeField] float jumpRadius = 0.25f;

    Rigidbody2D rigid;
    private float defaultMultiplier;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        
        if (playerSO != null)
        {
            maxHealth = playerSO.maxHealth;
            maxMana = playerSO.maxMana;
            shield = playerSO.shield;
            health = playerSO.health;
            mana = playerSO.mana;
            speed = playerSO.speed;
            jump = playerSO.jump;
            shootSpell = playerSO.shootSpell;
            manaRecovery = playerSO.manaRecovery;
        }

         //Debug.Log("PlayerSO " + playerSO.mana);
        //Debug.Log("Player " + mana);

        RecoverMana(manaRecovery);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerSO != null)
        {
            playerSO.health = health;
            playerSO.mana = mana;
            playerSO.shield = shield;
        }
    }

    public void LoseHealth(float loss)
    {
        this.health -= loss;
        if (this.health <= 0)
            { this.health = 0;
            SceneManager.LoadScene("MainMenu");}
        
    }

    public void GainHealth(float gain)
    {
        health += gain;
        if (health >= maxHealth)
            { this.health = maxHealth; }
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

    public void ChangeMaxHealth(float max)
    {
        maxHealth = playerSO.maxHealth = max;
    }

    public void ChangeMaxMana(float max)
    {
        maxMana = playerSO.maxMana = max;
    }

    public void AssignShootSpell(int spell)
    {
        shootSpell = spell;
        playerSO.shootSpell = spell;
    }

    public void ChangeShield(float shield)
    {
        this.shield = shield;
    }

    public void ReduceShield(float loss)
    {
        shield--;
    }

    public Rigidbody2D GetRigid() { return this.rigid; }
    public float GetSpeed() { return this.speed; }
    public float GetJump() { return this.jump; }
    public float GetJumpOffset() { return this.jumpOffset; }
    public float GetJumpRadius() { return this.jumpRadius; }
    public LayerMask GetGroundLayer() { return this.ground; }

}
