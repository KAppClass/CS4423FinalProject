using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeballShooter : MonoBehaviour
{
    [Header("Characters")]
    [SerializeField] Player player;
    [SerializeField] Enemy enemy;

    [Header("Door")]
    [SerializeField] DoorLeave doorLeave;

    [Header("Spell")]
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
                            ShootFireBall(player.transform.position);
                        
                            
                }

                yield return new WaitForSeconds(1f);
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
