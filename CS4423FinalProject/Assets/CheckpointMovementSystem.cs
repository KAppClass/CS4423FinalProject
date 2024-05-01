using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointMovementSystem : MonoBehaviour
{
    [Header("Checkpoints")]
    [SerializeField] List<Transform> checkpoints;

    [Header("Moveable Object")]
    [SerializeField] EnemySO enemySO;
    //[SerializeField] 

    [Header("Movement Stats")]
    [SerializeField] float waitTime = 0f;
    [SerializeField] int index = 0;
    [SerializeField] float moveTime;

    // Start is called before the first frame update
    void Start()
    {
        // if ( checkpoints.Count > 0)
        //     Move();
    }
    public void Move()
    {
        StartCoroutine(MoveRoutine());
        IEnumerator MoveRoutine()
        {
            if (checkpoints.Count > 0)
            {
                if(this.gameObject.tag == "Enemy1")
                    moveTime = enemySO.firstSpeed;
                else if(this.gameObject.tag == "Enemy2")
                    moveTime = enemySO.secondSpeed;

                while(true)
                {
                    yield return new WaitForSeconds(waitTime);
                    float timer = 0;
                    int nextIndex = (index+1)%checkpoints.Count;
                    while(timer < moveTime)
                    {
                        yield return null;
                        timer+=Time.deltaTime;
                        transform.localPosition = Vector3.Lerp(checkpoints[index].position,checkpoints[nextIndex].position,timer/moveTime);
                    }
                    transform.localPosition = checkpoints[nextIndex].position;
                    index=nextIndex;
                }
            }
        }
    }
}
