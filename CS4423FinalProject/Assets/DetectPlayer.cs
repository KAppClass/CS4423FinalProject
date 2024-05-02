using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPlayer : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D obj)
    {
        if(obj.GetComponent<Player>() != null)
        obj.transform.parent = this.transform;
    }   

    void OnTriggerExit2D(Collider2D obj)
    {
        if(obj.GetComponent<Player>() != null)
        obj.transform.parent = null;
    }   
}
