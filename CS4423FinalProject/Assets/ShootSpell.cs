using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootSpell : MonoBehaviour
{
    //[SerializeField] PlayerSO playerSO;
    [SerializeField] FireBall fireBall;
    [SerializeField] ManaSystem manaSystem;
    [SerializeField] PlayerSO playerSO;
    
    // Start is called before the first frame update
    void Start()
    {
        //transform.SetParent(creature.transform);
    }

    public void ShootSpells(int spell, Vector3 aim)
    {

        switch (spell)
        {
            case 0:


                    if (playerSO.mana >= 5f)
                    ShootFireBall(aim, 5f);
                    manaSystem.ReduceMana(spell);


                


            
                break;
            default:
                Debug.Log("Man Reduction Not working");
                break;
        }
        
    }


    void ShootFireBall(Vector3 aim, float speed)
    {
        FireBall spell = Instantiate(fireBall, transform.position, Quaternion.identity);
        spell.transform.rotation = Quaternion.LookRotation(transform.forward, aim - transform.position);
        spell.GetComponent<Rigidbody2D>().velocity = spell.transform.up * speed;
        Destroy(spell,10);
    }

}
