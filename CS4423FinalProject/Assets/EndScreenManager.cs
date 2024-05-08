using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreenManager : MonoBehaviour
{
    [SerializeField] Transition transition;
    [SerializeField] PlayerSO playerSO;
    [SerializeField] EnemySO enemySO;
    [SerializeField] InventorySO inventory;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MainMenu()
    {
        Debug.Log("Clicked");
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void StartGame()
    {
        PlayerPrefs.DeleteKey("Here");
        SetupPlayer();
        SetupEnemy();
        SetupInventory();
        transition.FadeToColor("SpellRoom");
    }

    void SetupPlayer()
    {
        playerSO.maxHealth = playerSO.health = playerSO.originalMaxHealth;
        playerSO.maxMana = playerSO.mana = playerSO.originalMaxMana;
        playerSO.shield = 0;
        playerSO.shootSpell = 0;
        playerSO.curScene = 1;
        playerSO.spellList.Clear();
        playerSO.spellList.Add(0);
        playerSO.loadSave = false;
    }

    void SetupEnemy()
    {
        enemySO.firstHealth = enemySO.firstMaxHealth = enemySO.firstOriginalHealth;
        enemySO.firstMana = enemySO.firstMaxMana = enemySO.firstOriginalMana;
        enemySO.firstSpeed = enemySO.firstOriginalSpeed;

        enemySO.secondHealth = enemySO.secondMaxHealth = enemySO.secondOriginalHealth;
        enemySO.secondMana = enemySO.secondMaxMana = enemySO.secondOriginalMana;
        enemySO.secondSpeed = enemySO.secondOriginalSpeed;

        enemySO.thirdHealth = enemySO.thirdMaxHealth = enemySO.thirdOriginalHealth;
        enemySO.thirdMana = enemySO.thirdMaxMana = enemySO.thirdOriginalMana;
        enemySO.thirdSpeed = enemySO.thirdOriginalSpeed;
    }

    void SetupInventory()
    {
        inventory.shootInventory.Clear();
        inventory.shootInventory.Add(1);
        inventory.shootInventory.Add(2);
        inventory.shootInventory.Add(3);

        inventory.passiveInventory.Clear();
        inventory.passiveInventory.Add(1);
        inventory.passiveInventory.Add(2);
        inventory.passiveInventory.Add(3);

        inventory.unopened = true;
    }
}
