using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NextRoom : MonoBehaviour
{
    [SerializeField] PlayerSO playerSO;
    [SerializeField] Transition transition;

    string curScene = "Boss";

    void Start()
    {
        curScene += playerSO.curScene;
        //Debug.Log(curScene);
    }

    public void OnTriggerEnter2D(Collider2D obj)
    {
        if((obj.gameObject.tag == "Player") && (SceneManager.GetActiveScene().name == "Boss3"))
        {
            transition.FadeToColor("End Screen");
        }
        
        if((obj.gameObject.tag == "Player") && (SceneManager.GetActiveScene().name == curScene))
        {
            playerSO.curScene += 1;
            playerSO.firstTime = true;
            transition.FadeToColor("Recovery and Save Room");
        }
        if((obj.gameObject.tag == "Player") && (SceneManager.GetActiveScene().name == "Recovery and Save Room"))
        {
            transition.FadeToColor("SpellRoom");
        }
        if((obj.gameObject.tag == "Player") && (SceneManager.GetActiveScene().name == "SpellRoom"))
        {
            playerSO.firstTime = false;
            transition.FadeToColor(curScene);
        }
        
    }
}
