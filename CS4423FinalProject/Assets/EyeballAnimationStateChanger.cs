using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeballAnimationStateChanger : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private string currState = "Rest";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeAnimationState(string newState)
    {
        if(currState == newState)
            return;
        
        currState = newState;
        animator.Play(currState);
    }

    public void StopAnimation()
    {
        animator.enabled = false;
    }
}
