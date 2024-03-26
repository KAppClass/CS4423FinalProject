using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] PlayerSO playerSO;
    public void StartGame()
    {
        playerSO.health = 10f;
        SceneManager.LoadScene("SpellRoom");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
