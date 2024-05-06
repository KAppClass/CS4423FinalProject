using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementManager : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] Player player;
    [SerializeField] PlayerSO playerSO;
    [SerializeField] GameObject body;
    [SerializeField] PlayerAnimationStateChanger changer;

    [Header("Enemy")]
    [SerializeField] Enemy first;


    public void MovePlayer(Vector3 direction)
    {
        Rigidbody2D rigid = player.GetRigid();
        float speed = playerSO.speed;

        Vector3 curVel = new Vector3(0, rigid.velocity.y, 0);

        MoveVel(direction, rigid, speed, curVel);

        if (direction.x != 0)
            changer.ChangeAnimationState("Move");
        else
            changer.ChangeAnimationState("Rest");

    }

    void Move(Vector3 direction, Rigidbody2D rigid, float speed) {
        

        rigid.velocity = direction * speed;
    }

    void MoveVel(Vector3 direction, Rigidbody2D rigid, float speed, Vector3 curVel) 
    {
        rigid.velocity = curVel + (direction * speed);
        if (rigid.velocity.x < 0)
            body.transform.localScale = new Vector3(-1, 1, 1);
        else if (rigid.velocity.x > 0)
            body.transform.localScale = new Vector3(1, 1, 1);
        
    }

    public void JumpPlayer()
    {
        Rigidbody2D rigid = player.GetRigid();
        Transform trans = player.transform;
        float jump = playerSO.jump;
        float jumpOffset = player.GetJumpOffset();
        float jumpRadius = player.GetJumpRadius();
        LayerMask ground = player.GetGroundLayer();

        Jump(rigid, jump, trans, jumpOffset, jumpRadius, ground);
    }

    void Jump(Rigidbody2D rigid, float jump, Transform trans, float jumpOffset, float jumpRadius, LayerMask ground)
    {
        // Debug.Log(trans.position + new Vector3(0,jumpOffset,0));
        // Debug.Log(jumpRadius);
        // Debug.Log(LayerMask.LayerToName(ground));
        // Debug.Log(Physics2D.OverlapCircleAll(trans.position + new Vector3(0,jumpOffset,0),jumpRadius,ground).Length);
        if(Physics2D.OverlapCircleAll(trans.position + new Vector3(0,jumpOffset,0),jumpRadius,ground).Length > 0) {
            Debug.Log("JUmping");
            rigid.AddForce(Vector3.up * jump, ForceMode2D.Impulse);
        }
    
    }
}
