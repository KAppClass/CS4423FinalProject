using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformTimer : MonoBehaviour
{
    [Header("All Platforms")]
    [SerializeField] List<GameObject> platforms;

    [Header("Doors")]
    [SerializeField] DoorEnter doorEnter;
    [SerializeField] DoorLeave doorLeave;
    
    [Header("Interval")]
    [SerializeField] float time;
    bool activate = true;

    // Start is called before the first frame update
    void Start()
    {

        //AlternatePlatforms();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(doorEnter.gameObject.activeSelf);
        if(activate && doorEnter.gameObject.activeSelf)
        {
            AlternatePlatforms();
            activate = false;
        }
    }

    void AlternatePlatforms()
    {
        StartCoroutine(PlatformRoutine());
        IEnumerator PlatformRoutine()
        {
            while(true)
            {
                //Debug.Log("HIT");
                ChangePlatforms(4, 5, 6, 7, 0, 1, 2, 3);

                if(!doorLeave.gameObject.activeSelf)
                    break;

                yield return new WaitForSeconds(time/2);

                if(!doorLeave.gameObject.activeSelf)
                    break;

                yield return new WaitForSeconds(time/2);

                if(!doorLeave.gameObject.activeSelf)
                    break;

                ChangePlatforms(0, 1, 2, 3, 4, 5, 6, 7);

                if(!doorLeave.gameObject.activeSelf)
                    break;

                yield return new WaitForSeconds(time/2);

                if(!doorLeave.gameObject.activeSelf)
                    break;

                yield return new WaitForSeconds(time/2);

                if(!doorLeave.gameObject.activeSelf)
                    break;

            }

            for (int i = 0; i < platforms.Count; i++)
                platforms[i].gameObject.SetActive(false);
        }
    }

    void ChangePlatforms(int floor1, int floor2, int floor3, int floor4, int floor5, int floor6, int floor7, int floor8)
    {
        platforms[floor1].gameObject.SetActive(true);
        platforms[floor2].gameObject.SetActive(true);
        platforms[floor3].gameObject.SetActive(true);
        platforms[floor4].gameObject.SetActive(false);

        platforms[floor5].gameObject.SetActive(false);
        platforms[floor6].gameObject.SetActive(false);
        platforms[floor7].gameObject.SetActive(false);
        platforms[floor8].gameObject.SetActive(false);
    }
}