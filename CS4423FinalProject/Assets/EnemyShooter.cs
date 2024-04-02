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

    [SerializeField] LayerMask playerLayer;

    bool playerSpotted = false;
    
    
    // Start is called before the first frame update
    void Start()
    {
        //transform.SetParent(creature.transform);
    }

    void Update()
    {
        //ray = new Ray(transform.position, transform.);
    }

    public void ShootSpells(int spell, Vector3 aim, int type)
    {
        //Raycast2D ray = new Ray2D(transform.position, aim);
        RaycastHit2D ray = Physics2D.Raycast(transform.position, aim-transform.position);

        Vector3 directon = aim * 10;
        //Debug.Log(ray.collider.name);

        if (ray.collider != null)
        {

            playerSpotted = ray.collider.CompareTag("Player");

            switch (spell)
            {
                case 0:

                        //Debug.Log("Enemy Mana: " + enemySO.firstMana);
                        
                        if ( playerSpotted && (enemySO.firstMana >= fireBall.GetCost()))
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
        
    }


    void ShootFireBall(Vector3 aim)
    {
        DemonFireBall spell = Instantiate(fireBall, transform.position, Quaternion.identity);
        spell.transform.rotation = Quaternion.LookRotation(transform.forward, aim - transform.position);
        spell.GetComponent<Rigidbody2D>().velocity = spell.transform.up * fireBall.GetSpeed();
        //Destroy(spell,10);
    }
}
