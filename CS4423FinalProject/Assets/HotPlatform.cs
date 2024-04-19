using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotPlatform : MonoBehaviour
{
    [SerializeField] HealthSystem health;
    [SerializeField] float loss = 0.5f;
    [SerializeField] float wait = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D obj)
    {
        if (obj.gameObject.tag == "Player")
        {
            // Debug.Log("Trigger Working", this);
            health.PlayerLoseHealth(loss, 1f);
            /*float timer = 0;

            while (timer < wait)
            {
                timer += Time.deltaTime;
            }*/

        }
    }


}
