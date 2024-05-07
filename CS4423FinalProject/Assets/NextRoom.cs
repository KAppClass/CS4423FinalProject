using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextRoom : MonoBehaviour
{
    [SerializeField] PlayerSO playerSO;
    string curScene = "Boss";

    void Start()
    {
        curScene += playerSO.curScene;
        //Debug.Log(curScene);
    }

    public void OnTriggerEnter2D(Collider2D obj)
    {
        
        if((obj.gameObject.tag == "Player") && (SceneManager.GetActiveScene().name == curScene))
        {
            playerSO.curScene += 1;
            playerSO.firstTime = true;
            SceneManager.LoadScene("Recovery and Save Room");
        }
        if((obj.gameObject.tag == "Player") && (SceneManager.GetActiveScene().name == "Recovery and Save Room"))
        {
            SceneManager.LoadScene("SpellRoom");
        }
        if((obj.gameObject.tag == "Player") && (SceneManager.GetActiveScene().name == "SpellRoom"))
        {
            playerSO.firstTime = false;
            SceneManager.LoadScene(curScene);
        }
    }
}
