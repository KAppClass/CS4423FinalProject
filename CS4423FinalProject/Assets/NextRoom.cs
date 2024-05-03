using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextRoom : MonoBehaviour
{
    [SerializeField] PlayerSO playerSO;
    string curScene = "Boss";

    public void OnTriggerEnter2D(Collider2D obj)
    {
        curScene += playerSO.curScene;
        Debug.Log(curScene);
        if((obj.gameObject.tag == "Player") && (SceneManager.GetActiveScene().name == curScene))
        {
            playerSO.curScene += 1;
            SceneManager.LoadScene("Recovery and Save Room");
        }
        if((obj.gameObject.tag == "Player") && (SceneManager.GetActiveScene().name == "Recovery and Save Room"))
        {
            SceneManager.LoadScene("SpellRoom");
        }
        if((obj.gameObject.tag == "Player") && (SceneManager.GetActiveScene().name == "SpellRoom"))
        {
            SceneManager.LoadScene(curScene);
        }
    }
}
