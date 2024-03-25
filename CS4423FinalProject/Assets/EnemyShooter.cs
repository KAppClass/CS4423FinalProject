using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    [Header("Spells")]
    [SerializeField] DemonFireBall fireBall;

    [Header("Needed Systems")]
    [SerializeField] ManaManager manaManager;
    

    [Header("Enemy")]
    [SerializeField] EnemySO enemySO;
    
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

                    //Debug.Log("Enemy Mana: " + enemySO.firstMana);
                     
                    if ( enemySO.firstMana >= fireBall.GetCost())
                    {
                        
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
        DemonFireBall spell = Instantiate(fireBall, transform.position, Quaternion.identity);
        spell.transform.rotation = Quaternion.LookRotation(transform.forward, aim - transform.position);
        spell.GetComponent<Rigidbody2D>().velocity = spell.transform.up * fireBall.GetSpeed();
        //Destroy(spell,10);
    }
}
