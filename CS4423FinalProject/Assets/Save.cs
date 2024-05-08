using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Save : MonoBehaviour
{
    public static Save singleton;

    [Header("Player")]
    [SerializeField] GameObject player;
    [SerializeField] PlayerSO playerSO;

    [Header("Necessary System")]
    [SerializeField] InventorySO inventory;

    bool active = true;

    void Awake()
    {
        if (singleton != null)
        {
            Debug.LogError("DUPLICATE SAVES DETECTED!");
        }

        if(!playerSO.firstTime && playerSO.loadSave)
            LoadSave();
    }


    public void OnTriggerStay2D(Collider2D obj)
    {
        if(obj.gameObject.tag == "Player" && Input.GetKey(KeyCode.E))
        {
            GetComponent<AudioSource>().Play();
            SaveFile();
            active = false;
            Debug.Log("Saved");
        }
    }

    void SaveFile()
    {
        PlayerPrefs.SetString("Here", "Exists");

        PlayerPrefs.SetFloat("Health",playerSO.health);
        PlayerPrefs.SetFloat("Mana",playerSO.mana);
        PlayerPrefs.SetFloat("Shield",playerSO.shield);

        PlayerPrefs.SetInt("Spell",playerSO.shootSpell);
        PlayerPrefs.SetInt("Passive Spell",playerSO.passiveSpell);
        PlayerPrefs.SetInt("Track Spell",playerSO.trackSpell);

        PlayerPrefs.SetInt("Number of Spells",playerSO.spellList.Count);
        PlayerPrefs.SetInt("Number of Passive Spells",inventory.passiveInventory.Count);
        PlayerPrefs.SetInt("Number of Shoot Spells",inventory.shootInventory.Count);
        
        Debug.Log("1. " + playerSO.spellList.Count + " 2. " +  inventory.passiveInventory.Count + " 3. " + inventory.shootInventory.Count);

        for(int i = 0; i < playerSO.spellList.Count; i++)
            PlayerPrefs.SetInt("Spell " + i,playerSO.spellList[i]);

        for(int j = 0; j < inventory.passiveInventory.Count; j++)
            PlayerPrefs.SetInt("Inventory Passive Spell " + j,inventory.passiveInventory[j]);

        for(int k = 0; k < inventory.shootInventory.Count; k++)
        {
            PlayerPrefs.SetInt("Inventory Shoot Spell" + k,inventory.shootInventory[k]);
            //Debug.Log(PlayerPrefs.GetInt("Inventory Shoot Spell" + k));
        }

        PlayerPrefs.SetInt("Current Scene",playerSO.curScene);

        playerSO.loadSave = true;

        
    }

    void LoadSave()
    {
        player.transform.position = this.transform.position;

        playerSO.health = PlayerPrefs.GetFloat("Health");
        playerSO.mana = PlayerPrefs.GetFloat("Mana");
        playerSO.shield = PlayerPrefs.GetFloat("Shield");

        playerSO.shootSpell = PlayerPrefs.GetInt("Spell");
        playerSO.passiveSpell = PlayerPrefs.GetInt("Passive Spell");
        playerSO.trackSpell = PlayerPrefs.GetInt("Track Spell");

        int spellsNum = PlayerPrefs.GetInt("Number of Spells");
        int passiveNum = PlayerPrefs.GetInt("Number of Passive Spells");
        int shootNum = PlayerPrefs.GetInt("Number of Shoot Spells");

        //Debug.Log("1. " + spellsNum + " 2. " + passiveNum + " 3. " + shootNum);

        playerSO.spellList.Clear();
        inventory.passiveInventory.Clear();
        inventory.shootInventory.Clear();

        for(int i = 0; i < spellsNum; i++)
            playerSO.spellList.Add(PlayerPrefs.GetInt("Spell " + i));

        for(int j = 0; j < passiveNum; j++)
            inventory.passiveInventory.Add(PlayerPrefs.GetInt("Inventory Passive Spell " + j));

        for(int k = 0; k < shootNum; k++)
        {
            inventory.shootInventory.Add(PlayerPrefs.GetInt("Inventory Shoot Spell" + k));
            Debug.Log(PlayerPrefs.GetInt("Inventory Shoot Spell" + k));
        }

        playerSO.curScene = PlayerPrefs.GetInt("Current Scene");
    }

    
}
