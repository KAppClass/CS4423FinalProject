using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassiveSpellsManager : MonoBehaviour
{
    [SerializeField] PlayerSO playerSO;
    [SerializeField] Player player;

    [Header("Spell Values")]
    [SerializeField] float maxHealth = 20f;
    [SerializeField] float maxMana = 20f;
    [SerializeField] float shield = 5f;

    // Start is called before the first frame update
    void Start()
    {
        if(playerSO.passiveSpell == 0)
        {
            playerSO.maxHealth = playerSO.originalMaxHealth;
            playerSO.maxMana = playerSO.originalMaxMana;
            playerSO.shield = 0;
        }
        else
        {
            ActivateSpell();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ActivateSpell()
    {
        switch(playerSO.passiveSpell)
        {
            case 1:
                player.ChangeMaxHealth(maxHealth);
                player.ChangeMaxMana(playerSO.originalMaxMana);
                player.ChangeShield(0);
                break;
            case 2:
                player.ChangeMaxHealth(playerSO.originalMaxHealth);
                player.ChangeMaxMana(maxMana);
                player.ChangeShield(0);
                break;
            case 3:
                player.ChangeMaxHealth(playerSO.originalMaxHealth);
                player.ChangeMaxMana(playerSO.originalMaxMana);
                player.ChangeShield(shield);
                break;
            default:
                Debug.Log("Passive Spell not working");
                break;
        }
    }

}