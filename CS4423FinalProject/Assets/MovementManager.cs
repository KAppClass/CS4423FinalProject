using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementManager : MonoBehaviour
{

    [SerializeField] Player player;
    [SerializeField] PlayerSO playerSO;
    [SerializeField] Enemy first;
    [SerializeField] LayerMask layer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MovePlayer(Vector3 direction)
    {
        Rigidbody2D rigid = player.GetRigid();
        float speed = playerSO.speed;

        Vector3 curVel = new Vector3(0, rigid.velocity.y, 0);

        MoveVel(direction, rigid, speed, curVel);

    }

    void Move(Vector3 direction, Rigidbody2D rigid, float speed) {
        

        rigid.velocity = direction * speed;
    }

    void MoveVel(Vector3 direction, Rigidbody2D rigid, float speed, Vector3 curVel) 
    {
        rigid.velocity = curVel + (direction * speed);
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
