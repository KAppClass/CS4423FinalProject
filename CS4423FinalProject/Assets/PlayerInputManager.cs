using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Input : MonoBehaviour
{
    [SerializeField] MovementManager movement;
    [SerializeField] Player player;


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

        movement.MovePlayer(input);

    }

}
