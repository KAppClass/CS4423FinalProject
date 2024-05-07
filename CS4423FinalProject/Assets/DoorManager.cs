using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManager : MonoBehaviour
{
    [SerializeField] DoorEnter doorEnter;
    [SerializeField] DoorLeave doorLeave;
    

    public void OpenExit()
    {
        doorLeave.gameObject.SetActive(false);
        GetComponent<AudioSource>().Play();
    }

    public void CloseEntrance()
    {
        doorEnter.gameObject.SetActive(true);
        GetComponent<AudioSource>().Play();
    }
}
