using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstEnemy : MonoBehaviour
{
    [Header("Stats")]

    [SerializeField] float maxHealth = 10f;
    [SerializeField] float maxMana = 20f;
    [SerializeField] float health = 10f;
    [SerializeField] float mana = 20f;
    [SerializeField] float speed;
    [SerializeField] int spell;
    [SerializeField] float jump = 15f;
    [SerializeField] float healthLossMultiplier = 1f;
    [SerializeField] float manaRecovery;

    float defaultMultiplier;

    //[SerializeField]
    // Start is called before the first frame update
    void Start()
    {
        defaultMultiplier = healthLossMultiplier;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Health: " + health);
    }

    public void LoseHealth(float loss)
    {
        float afterHealth = this.health - (loss * healthLossMultiplier);
        if (afterHealth <= 0)
            { Destroy(this); }
        else
        {
            this.health = afterHealth;
        }
    }

    public void TempChangeMultiplier(float multiplier, float time)
    {
        healthLossMultiplier = multiplier;
        float timer = 0;
        while(timer < time)
        {
            timer+=Time.deltaTime;
        }
        healthLossMultiplier = defaultMultiplier;
    }
}
