using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotPlatformManager : MonoBehaviour
{
    [SerializeField] EnemySO enemySO;

    [SerializeField] List<HotPlatform> platforms;
    int platform1, platform2, platform3;

    [SerializeField] float waitActivation;
    [SerializeField] float activationTime;
    // Start is called before the first frame update
    void Start()
    {
        CatchFire();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void CatchFire()
    {
        StartCoroutine(StartFire());
        IEnumerator StartFire()
        {
            while(true)
            {
                
                if(enemySO.secondHealth == 0)
                    break;

                ChoosePlatforms();

                yield return new WaitForSeconds(activationTime);

                //Debug.Log("Activated", this);

                if(enemySO.secondHealth == 0)
                    break;

                platforms[platform1].gameObject.SetActive(true);
                platforms[platform2].gameObject.SetActive(true);
                platforms[platform3].gameObject.SetActive(true);

                if(enemySO.secondHealth == 0)
                {
                    platforms[platform1].gameObject.SetActive(false);
                    platforms[platform2].gameObject.SetActive(false);
                    platforms[platform3].gameObject.SetActive(false);
                    break;
                }

                yield return new WaitForSeconds(waitActivation);

                //Debug.Log("Activated", this);

                platforms[platform1].gameObject.SetActive(false);
                platforms[platform2].gameObject.SetActive(false);
                platforms[platform3].gameObject.SetActive(false);

            }
        }
    }

    void ChoosePlatforms()
    {
        platform1 = Random.Range(0,(platforms.Count));
        platform2 = Random.Range(0,(platforms.Count));

        while(platform2 == platform1)
            platform2 = Random.Range(0,(platforms.Count-1));

        platform3 = Random.Range(0,(platforms.Count-1));

        while((platform3 == platform1) || (platform3 == platform2))
            platform3 = Random.Range(0,(platforms.Count));
    }

}
