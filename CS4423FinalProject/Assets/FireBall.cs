using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{

    [Header("States")]

    [SerializeField] float damage = 2;
    [SerializeField] float cost = ;
    [SerializeField] float damageMultiplier;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.gameObject.tag == "Enviroment")
        {
            Destroy(this.gameObject);
        }
    }
}
