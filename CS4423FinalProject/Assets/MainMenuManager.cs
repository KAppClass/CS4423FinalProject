using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] PlayerSO playerSO;
    [SerializeField] EnemySO enemySO;
    [SerializeField] InventorySO inventory;
    public void StartGame()
    {
        SetupPlayer();
        SetupEnemy();
        SetupInventory();
        SceneManager.LoadScene("SpellRoom");
    }

    public void QuitGame()
    {
        Application.Quit();
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

        inventory.unopened = true;
    }
}
