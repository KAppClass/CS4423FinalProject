using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [Header("Stats")]

    [SerializeField] float maxHealth = 5f;
    [SerializeField] float maxMana = 5f;
    [SerializeField] float health = 5f;
    [SerializeField] float mana = 10f;
    [SerializeField] float speed = 7f;

    [Header("Effects")]
    [SerializeField] float jump = 4f;
    [SerializeField] float healthLossMultiplier = 1f;

    [Header("Physics")]

    [SerializeField] LayerMask ground;
    [SerializeField] float jumpOffset = -0.5f;
    [SerializeField] float jumpRadius = 0.25f;

    Rigidbody2D rigid;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoseHealth(float loss)
    {
        float afterHealth = this.health - (loss * healthLossMultiplier);
        if (afterHealth <= 0)
            { this.health = 0; }
        else
        {
            health = afterHealth;
        }
    }

    public void GainHealth(float gain)
    {
        float afterHealth = this.health + gain;
        if (afterHealth >= maxHealth)
            { this.health = maxHealth; }
        else
        {
            health = afterHealth;
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

    public void GainMana(float gain)
    {
        float afterMana = this.mana + gain;
        if (afterMana >= maxMana)
            { this.mana = maxMana; }
        else
        {
            mana = afterMana;
        }
    }
    

    public Rigidbody2D GetRigid() { return this.rigid; }
    public float GetSpeed() { return this.speed; }
    public float GetJump() { return this.jump; }
    public float GetJumpOffset() { return this.jumpOffset; }
    public float GetJumpRadius() { return this.jumpRadius; }
    public LayerMask GetGroundLayer() { return this.ground; }

}
