using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManager : MonoBehaviour
{
    [SerializeField] DoorEnter doorEnter;
    [SerializeField] DoorLeave doorLeave;
    

    public void OpenExit()
    {
        doorLeave.gameObject.active = false;
    }

    public void CloseEntrance()
    {
        doorEnter.gameObject.active = true;
    }
}
