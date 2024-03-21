using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Input : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] PlayerSO playerSO;
    [SerializeField] MovementManager movement;
    [SerializeField] ShootSpell shooter;

    //ShootSpell shooter;

    void Start()
    {
        //shooter = this.GetComponent<ShootSpell>();
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
    }

    void GetInput()
    {
         Vector3 input = Vector3.zero;


        if(Input.GetKey(KeyCode.A)) { input.x += -1; }

        if(Input.GetKey(KeyCode.D)) { input.x += 1; }

        if(Input.GetKeyDown(KeyCode.Space)) { movement.JumpPlayer(); }

        if( Input.GetMouseButtonDown(0))
        { 
            shooter.ShootSpells(playerSO.spell, Camera.main.ScreenToWorldPoint(Input.mousePosition)); 

        }
        else
        {
            //player.RecoverMana(playerSO.manaRecovery);
        }

        

        movement.MovePlayer(input);

    }

}
