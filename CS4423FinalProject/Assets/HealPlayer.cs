using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealPlayer : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] float recover = 5f;
    bool active = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    /*void Update()
    {
        PlayerRecovery();
    }*/

    public void OnTriggerStay2D(Collider2D obj)
    {
        if(obj.gameObject.tag == "Player")
            PlayerRecovery();
    }

    void PlayerRecovery()
    {
        if(active && Input.GetKey(KeyCode.E))
        {
            GetComponent<AudioSource>().Play();
            //Debug.Log("Healing Player");
            player.GainHealth(recover);
            active = false;
        }
    }
}
