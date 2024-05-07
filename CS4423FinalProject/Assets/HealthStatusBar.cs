using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthStatusBar : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] PlayerSO playerSO;

    [Header("Health Incidator")]
    public Transform healthForegroundTransform;
    public Transform shieldForegroundTransform;

    [Header("Bar Details")]
    public float barSpeed = 5f;
    public float shieldAmount = 10f;
    
    [Range (0f,1f)]
    public float healthPercentage;
    [Range (0f,1f)]
    public float shieldPercentage;

    // Start is called before the first frame update
    void Start()
    {
        healthPercentage = 0;
        shieldPercentage = 0;

        healthForegroundTransform.localScale = new Vector3(healthPercentage,1f,1f);
        shieldForegroundTransform.localScale = new Vector3(shieldPercentage,1f,1f);
    }

    // Update is called once per frame
    void Update()
    {
        healthPercentage = playerSO.health/playerSO.maxHealth;
        shieldPercentage = playerSO.shield/shieldAmount;

        float healthBarSize = Mathf.Lerp(healthForegroundTransform.localScale.x, healthPercentage, Time.deltaTime*barSpeed);
        float shieldBarSize = Mathf.Lerp(shieldForegroundTransform.localScale.x, shieldPercentage, Time.deltaTime*barSpeed);

        healthForegroundTransform.localScale = new Vector3(healthBarSize,1f,1f);
        shieldForegroundTransform.localScale = new Vector3(shieldBarSize,1f,1f);

    }
}
