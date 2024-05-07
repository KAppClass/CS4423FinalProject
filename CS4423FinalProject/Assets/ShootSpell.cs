using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootSpell : MonoBehaviour
{
    [Header("Spells")]
    [SerializeField] BasicBall basicBall;
    [SerializeField] FireBall fireBall;
    [SerializeField] IceBall iceBall;
    [SerializeField] LightingBall lightingBall;

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
                if (playerSO.mana >= basicBall.GetCost())
                    {
                        //Debug.Log("Shooter User2: " + playerSO.mana,this);
                        ShootBasicBall(aim);
                        manaManager.ReduceMana(basicBall.GetCost(), type);
                        GetComponent<AudioSource>().Play();
                    }
                break;
            case 1:
                     //Debug.Log("Shooter User1: " + playerSO.mana,this);

                    if (playerSO.mana >= fireBall.GetCost())
                    {
                        //Debug.Log("Shooter User2: " + playerSO.mana,this);
                        ShootFireBall(aim);
                        manaManager.ReduceMana(fireBall.GetCost(), type);
                        GetComponent<AudioSource>().Play();
                    }
            
                break;
            case 2:
            if (playerSO.mana >= iceBall.GetCost())
                    {
                        //Debug.Log("Shooter User2: " + playerSO.mana,this);
                        ShootIceBall(aim);
                        manaManager.ReduceMana(iceBall.GetCost(), type);
                        GetComponent<AudioSource>().Play();
                    }
            
                break;
            case 3:
            if (playerSO.mana >= lightingBall.GetCost())
                    {
                        //Debug.Log("Shooter User2: " + playerSO.mana,this);
                        ShootLightningBall(aim);
                        manaManager.ReduceMana(lightingBall.GetCost(), type);
                        GetComponent<AudioSource>().Play();
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

    void ShootIceBall(Vector3 aim)
    {
        IceBall spell = Instantiate(iceBall, transform.position, Quaternion.identity);
        spell.transform.rotation = Quaternion.LookRotation(transform.forward, aim - transform.position);
        spell.GetComponent<Rigidbody2D>().velocity = spell.transform.up * iceBall.GetSpeed();
        //Destroy(spell,10);
    }

    void ShootLightningBall(Vector3 aim)
    {
        LightingBall spell = Instantiate(lightingBall, transform.position, Quaternion.identity);
        spell.transform.rotation = Quaternion.LookRotation(transform.forward, aim - transform.position);
        spell.GetComponent<Rigidbody2D>().velocity = spell.transform.up * lightingBall.GetSpeed();
        //Destroy(spell,10);
    }

    void ShootBasicBall(Vector3 aim)
    {
        BasicBall spell = Instantiate(basicBall, transform.position, Quaternion.identity);
        spell.transform.rotation = Quaternion.LookRotation(transform.forward, aim - transform.position);
        spell.GetComponent<Rigidbody2D>().velocity = spell.transform.up * basicBall.GetSpeed();
        //Destroy(spell,10);
    }

}
