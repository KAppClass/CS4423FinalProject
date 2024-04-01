using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthStatusBar : MonoBehaviour
{
    [SerializeField] PlayerSO playerSO;
    public Transform foregroundTransform;
    public float barSpeed = 5f;
    
    [Range (0f,1f)]
    public float percentage;

    // Start is called before the first frame update
    void Start()
    {
        percentage = 0;

        foregroundTransform.localScale = new Vector3(percentage,1f,1f);
    }

    // Update is called once per frame
    void Update()
    {
        percentage = playerSO.health/playerSO.maxHealth;

        float barSize = Mathf.Lerp(foregroundTransform.localScale.x, percentage, Time.deltaTime*barSpeed);

        foregroundTransform.localScale = new Vector3(barSize,1f,1f);

        //foregroundTransform.localScale = new Vector3(percentage,1f,1f);

        

    }
}
