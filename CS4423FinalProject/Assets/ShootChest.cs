using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootChest : MonoBehaviour
{
    [SerializeField] PlayerSO playerSO;
    [SerializeField] Player player;
    [SerializeField] InventorySO inventory;
    private int chosenSpell;
    private int index;
    // Start is called before the first frame update
    void Start()
    {
        if(inventory.unopened != true)
            inventory.unopened = true;
        ChooseSpell();
    }

    // Update is called once per frame
    void Update()
    {
        OpenChest();
    }

    void OpenChest()
    {
        if(inventory.unopened && Input.GetKeyDown(KeyCode.E))
        {
            player.AssignShootSpell(chosenSpell);
            playerSO.spellList.Add(chosenSpell);
            //inventory.shootInventory.RemoveAt(index);
            inventory.unopened = false;
        }
    }

    void ChooseSpell()
    {
        index = Random.Range(0,(inventory.shootInventory.Count-1));
        chosenSpell = inventory.shootInventory[index];
    }
}
