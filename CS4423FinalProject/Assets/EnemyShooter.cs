using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    [Header("Spells")]
    [SerializeField] DemonFireBall fireBall;
    [SerializeField] DemonLightningBall lightningBall;
    [SerializeField] DemonPlantBall plantBall;

    [Header("Needed Systems")]
    [SerializeField] ManaManager manaManager;
    [SerializeField] EnemyAnimationStateChanger changer;
    

    [Header("Enemy")]
    [SerializeField] EnemySO enemySO;

    [SerializeField] LayerMask playerLayer;

    bool playerSpotted = false;
    float enemyMana;
    
    
    // Start is called before the first frame update
    void Start()
    {
        if(this.transform.parent.gameObject.tag == "Enemy1")
            enemyMana = enemySO.firstMana;
        if(this.transform.parent.gameObject.tag == "Enemy2")
            enemyMana = enemySO.secondMana;
        if(this.transform.parent.gameObject.tag == "Enemy3")
            enemyMana = enemySO.thirdMana;

        //transform.SetParent(creature.transform);
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
                        
                        if ( playerSpotted && (enemyMana >= fireBall.GetCost()))
                        {
                            ShootFireBall(aim);
                            manaManager.ReduceMana(fireBall.GetCost(), type);

                        }
                
                    break;
                case 1:

                        //Debug.Log("Enemy Mana: " + enemySO.firstMana);
                        
                        if ( playerSpotted && (enemyMana >= lightningBall.GetCost()))
                        {
                            
                            ShootLightningBall(aim);
                            manaManager.ReduceMana(lightningBall.GetCost(), type);
                        }
                
                    break;
                case 2:

                        //Debug.Log("Enemy Mana: " + enemySO.firstMana);
                        
                        if ( playerSpotted && (enemyMana >= plantBall.GetCost()))
                        {
                            changer.ChangeAnimationState("Attack Start");
                            ShootPlantBall(aim);
                            manaManager.ReduceMana(plantBall.GetCost(), type);
                            changer.ChangeAnimationState("Attack End");
                            changer.ChangeAnimationState("Rest");
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

    void ShootPlantBall(Vector3 aim)
    {
        DemonPlantBall spell = Instantiate(plantBall, transform.position, Quaternion.identity);
        spell.transform.rotation = Quaternion.LookRotation(transform.forward, aim - transform.position);
        spell.GetComponent<Rigidbody2D>().velocity = spell.transform.up * plantBall.GetSpeed();
        //Destroy(spell,10);
    }

    void ShootLightningBall(Vector3 aim)
    {
        DemonLightningBall spell = Instantiate(lightningBall, transform.position, Quaternion.identity);
        spell.transform.rotation = Quaternion.LookRotation(transform.forward, aim - transform.position);
        spell.GetComponent<Rigidbody2D>().velocity = spell.transform.up * lightningBall.GetSpeed();
        //Destroy(spell,10);
    }
}
