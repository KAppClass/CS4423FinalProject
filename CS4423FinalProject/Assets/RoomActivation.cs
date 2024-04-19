using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomActivation : MonoBehaviour
{
    [SerializeField] DoorManager door;
    [SerializeField] Enemy enemy;
    

    public void OnTriggerEnter2D(Collider2D obj)
    {
        if(obj.gameObject.tag == "Player")
        {
            door.CloseEntrance();
            if(enemy != null)
            {enemy.Attack();}
            this.gameObject.SetActive(false);
        }
    }
}
