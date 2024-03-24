using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootSpell : MonoBehaviour
{
    [Header("Spells")]
    [SerializeField] FireBall fireBall;

    [Header("Needed Systems")]
    [SerializeField] ManaManager manaManager;
    

    [Header("Player")]
    [SerializeField] PlayerSO playerSO;


    // Start is called before the first frame update
    void Start()
    {
        //transform.SetParent(creature.transform);
    }

    public void ShootSpells(int spell, Vector3 aim, int type)
    {

        switch (spell)
        {
            case 0:
                     //Debug.Log("Shooter User1: " + playerSO.mana,this);

                    if (playerSO.mana >= fireBall.GetCost())
                    {
                        //Debug.Log("Shooter User2: " + playerSO.mana,this);
                        ShootFireBall(aim);
                        manaManager.ReduceMana(fireBall.GetCost(), type);
                    }
            
                break;
            default:
                Debug.Log("Man Reduction Not working");
                break;
        }
        
    }


    void ShootFireBall(Vector3 aim)
    {
        FireBall spell = Instantiate(fireBall, transform.position, Quaternion.identity);
        spell.transform.rotation = Quaternion.LookRotation(transform.forward, aim - transform.position);
        spell.GetComponent<Rigidbody2D>().velocity = spell.transform.up * fireBall.GetSpeed();
        //Destroy(spell,10);
    }

}
