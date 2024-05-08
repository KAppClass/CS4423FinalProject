using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassiveChest : MonoBehaviour
{
    [SerializeField] PlayerSO playerSO;
    [SerializeField] InventorySO inventory;
    int chosenSpell;
    private int index;
    // Start is called before the first frame update
    void Start()
    {
        if(inventory.unopened != true)
            inventory.unopened = true;
        ChooseSpell();
    }

    // Update is called once per frame
    /*void Update()
    {
        OpenChest();
    }*/

    public void OnTriggerStay2D(Collider2D obj)
    {
        if(obj.gameObject.tag == "Player" && Input.GetKey(KeyCode.E))
        {
            OpenChest();
        }
    }

    void OpenChest()
    {
        if(inventory.unopened && Input.GetKeyDown(KeyCode.E))
        {
            GetComponent<AudioSource>().Play();
            playerSO.passiveSpell = chosenSpell;
            //inventory.shootInventory.RemoveAt(index);
            inventory.unopened = false;
        }
    }

    void ChooseSpell()
    {
        index = Random.Range(0,(inventory.passiveInventory.Count));
        chosenSpell = inventory.shootInventory[index];
    }
}
