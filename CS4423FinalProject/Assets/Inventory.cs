using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Inventory")]
public class InventorySO : ScriptableObject
{
    public List<int> passiveInventory;
    public List<int> shootInventory;
    public bool unopened;
}
