using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationStateChanger : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private string currState = "Rest";

     public void ChangeAnimationState(string newState)
    {
        if(currState == newState)
            return;
        
        currState = newState;
        animator.Play(currState);
    }

}
