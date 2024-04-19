using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TestText : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;
    //[SerializeField] FirstEnemy first;

    public static TestText singleton;

    //float health = first.GetHealth();
    void Awake()
    {
        if (singleton != null)
        {
            Destroy(this.gameObject);
        }

        singleton = this;
    }

    public void ShowHealth(float health)
    {
        text.text = "Health: " + health;
    }
}
