using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeballShooter : MonoBehaviour
{

    [SerializeField] Player player;
    [SerializeField] Enemy enemy;
    [SerializeField] DemonFireBall fireBall;

    bool playerSpotted = false;
    // Start is called before the first frame update
    void Start()
    {
        ShootSpell();
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    void ShootSpell()
    {
        StartCoroutine(ShootRoutine());
        IEnumerator ShootRoutine()
        {
            while(true)
            {
                if(enemy.GetHealth() == 0)
                    break;
                RaycastHit2D ray = Physics2D.Raycast(transform.position, player.transform.position - transform.position);

                Vector3 directon = player.transform.position * 10;
                //Debug.Log(ray.collider.name);

                if (ray.collider != null)
                {

                    playerSpotted = ray.collider.CompareTag("Player");
                                
                        if ( playerSpotted)        
                            ShootFireBall(player.transform.position);
                        
                            
                }
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
