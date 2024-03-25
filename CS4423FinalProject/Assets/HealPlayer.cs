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
    void Update()
    {
        PlayerRecovery();
    }

    void PlayerRecovery()
    {
        if(active && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Healing Player");
            player.GainHealth(recover);
            active = false;
        }
    }
}
