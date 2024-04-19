using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextRoom : MonoBehaviour
{
    [SerializeField] PlayerSO playerSO;
    string curScene;

    public void OnTriggerEnter2D(Collider2D obj)
    {
        curScene = "Boss" + playerSO.curScene;
        if((obj.gameObject.tag == "Player") && (SceneManager.GetActiveScene().name == curScene))
        {
            SceneManager.LoadScene("Recovery and Save Room");
        }
        if((obj.gameObject.tag == "Player") && (SceneManager.GetActiveScene().name == "Recovery and Save Room"))
        {
            playerSO.curScene++;
            SceneManager.LoadScene("SpellRoom");
        }
        if((obj.gameObject.tag == "Player") && (SceneManager.GetActiveScene().name == "SpellRoom"))
        {
            SceneManager.LoadScene(curScene);
        }
    }
}
