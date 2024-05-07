using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/PlayerSo")]
public class PlayerSO : ScriptableObject
{
    private void OnEnable() => hideFlags = HideFlags.DontUnloadUnusedAsset;
    public float originalMaxHealth;
    public float originalMaxMana;
    public float maxHealth;
    public float maxMana;
    public float shield;
    public float health;
    public float mana;
    public float speed = 7f;
    public int shootSpell = 0;
    public List<int> spellList;
    public int trackSpell = 0;
    public int passiveSpell = 0;

    public float jump = 15f;
    public float manaRecovery = 0.5f;

    public int curScene = 0;
    public bool loadSave = false;
    public bool firstTime = true;
}
