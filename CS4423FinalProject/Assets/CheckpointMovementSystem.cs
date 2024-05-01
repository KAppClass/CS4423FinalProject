using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointMovementSystem : MonoBehaviour
{
    [SerializeField] List<Transform> checkpoints;
    [SerializeField] float waitTime = 0f;
    [SerializeField] int index = 0;
    [SerializeField] float moveTime = 5f;

    // Start is called before the first frame update
    void Start()
    {
        if ( checkpoints.Count > 0)
            Move();
    }
    void Move()
    {
        StartCoroutine(MoveRoutine());
        IEnumerator MoveRoutine()
        {
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
