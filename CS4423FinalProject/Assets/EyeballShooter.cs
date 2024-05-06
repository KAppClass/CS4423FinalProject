using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeballShooter : MonoBehaviour
{
    [Header("Characters")]
    [SerializeField] Player player;
    [SerializeField] Enemy enemy;

    [Header("Necessary")]
    [SerializeField] DoorLeave doorLeave;
    [SerializeField] EyeballAnimationStateChanger changer;

    [Header("Spell")]
    [SerializeField] DemonDarkBall darkBall;

    bool playerSpotted = false;
    // Start is called before the first frame update
    void Start()
    {
        ShootSpell();
    }


    public void ShootSpell()
    {
        StartCoroutine(ShootRoutine());
        IEnumerator ShootRoutine()
        {
            while(doorLeave.gameObject.activeSelf)
            {
                RaycastHit2D ray = Physics2D.Raycast(transform.position, player.transform.position - transform.position);

                Vector3 directon = player.transform.position * 10;
                //Debug.Log(ray.collider.name);

                if (ray.collider != null)
                {

                    playerSpotted = ray.collider.CompareTag("Player");
                                
                        if ( playerSpotted)
                        {     
                            changer.ChangeAnimationState("Start Attack");
                            ShootDarkBall(player.transform.position);
                            changer.ChangeAnimationState("End Attack");
                            yield return new WaitForSeconds(0.25f);
                            changer.ChangeAnimationState("Rest");

                        }
                        else
                            changer.ChangeAnimationState("Rest");
                        
                            
                }

                yield return new WaitForSeconds(1f);
            }
            changer.StopAnimation();

        }
        
    }

    void ShootDarkBall(Vector3 aim)
    {
        DemonDarkBall spell = Instantiate(darkBall, transform.position, Quaternion.identity);
        spell.transform.rotation = Quaternion.LookRotation(transform.forward, aim - transform.position);
        spell.GetComponent<Rigidbody2D>().velocity = spell.transform.up * darkBall.GetSpeed();
        //Destroy(spell,10);
    }
}
