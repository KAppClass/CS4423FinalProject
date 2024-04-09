using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/PlayerSo")]
public class PlayerSO : ScriptableObject
{
    private void OnEnable() => hideFlags = HideFlags.DontUnloadUnusedAsset;
    public float originalMaxHealth = 5f;
    public float originalMaxMana = 10f;
    public float maxHealth = 5f;
    public float maxMana = 10f;
    public float shield = 0f;
    public float health = 5f;
    public float mana = 10f;
    public float speed = 7f;
    public int shootSpell = 0;
    public List<int> spellList;
    public int trackSpell = 0;
    public int meleeSpell = 0;
    public int passiveSpell = 0;

    public float jump = 15f;
    public float healthLossMultiplier = 1f;
    public float manaRecovery = 0.5f;

}
