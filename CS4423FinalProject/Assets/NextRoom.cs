using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextRoom : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D obj)
    {
        if((obj.gameObject.tag == "Player") && (SceneManager.GetActiveScene().name == "Boss1"))
        {
            SceneManager.LoadScene("Recovery and Save Room");
        }
        if((obj.gameObject.tag == "Player") && (SceneManager.GetActiveScene().name == "Recovery and Save Room"))
        {
            SceneManager.LoadScene("SpellRoom");
        }
        if((obj.gameObject.tag == "Player") && (SceneManager.GetActiveScene().name == "SpellRoom"))
        {
            SceneManager.LoadScene("Boss1");
        }
    }
}
