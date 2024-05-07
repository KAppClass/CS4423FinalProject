using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeballShooter : MonoBehaviour
{
    [Header("Manager")]
    [SerializeField] DemonDarkBallManager manager;
    
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

                            manager.ShootDarkBall(player.transform.position, this);
                            GetComponent<AudioSource>().Play();
                            
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

    
}
