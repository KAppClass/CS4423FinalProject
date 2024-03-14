using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [Header("Stats")]

    [SerializeField] float health = 5f;
    [SerializeField] float mana = 10f;
    [SerializeField] float speed = 7f;
    [SerializeField] float jump = 4f;

    [Header("Physics")]

    [SerializeField] LayerMask ground;
    [SerializeField] float jumpOffset = -0.5f;
    [SerializeField] float jumpRadius = 0.25f;

    float manaCost = 1f;
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
        float afterHealth = this.health - loss;
        if (afterHealth <= 0)
            { this.health = 0; }
        else
        {
            health = afterHealth;
        }
    }

    public Rigidbody2D GetRigid() { return this.rigid; }
    public float GetSpeed() { return this.speed; }
    public float GetJump() { return this.jump; }
    public float GetJumpOffset() { return this.jumpOffset; }
    public float GetJumpRadius() { return this.jumpRadius; }
    public LayerMask GetGroundLayer() { return this.ground; }
}
