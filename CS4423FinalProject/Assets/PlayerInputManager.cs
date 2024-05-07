using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Input : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] Player player;
    [SerializeField] PlayerSO playerSO;

    [Header("Necessary Systems")]
    [SerializeField] MovementManager movement;
    [SerializeField] ShootSpell shooter;
    [SerializeField] PauseMenu pause;


    // Update is called once per frame
    void Update()
    {
        GetInput();
    }

    void GetInput()
    {
         Vector3 input = Vector3.zero;

        if (Input.GetKeyDown(KeyCode.X))
        {
            PauseMenu.isPause = !PauseMenu.isPause;
            pause.CheckPause();
        }

        if(!PauseMenu.isPause)
        {
            if(Input.GetKey(KeyCode.A)) { input.x += -1; }

            if(Input.GetKey(KeyCode.D)) { input.x += 1; }

            if(Input.GetKeyDown(KeyCode.Space)) { 
                
                movement.JumpPlayer(); }

            if( Input.GetMouseButtonDown(0))
            { 
                shooter.ShootSpells(playerSO.shootSpell, Camera.main.ScreenToWorldPoint(Input.mousePosition), 0); 

            }

            if( Input.GetMouseButtonDown(1))
            { 
                playerSO.trackSpell = (playerSO.trackSpell+1)%playerSO.spellList.Count;
                playerSO.shootSpell = playerSO.spellList[playerSO.trackSpell];

            }
        

            movement.MovePlayer(input);

        }
        else{

        }

    }

}
