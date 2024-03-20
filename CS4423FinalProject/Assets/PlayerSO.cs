using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/PlayerSo")]
public class PlayerSO : ScriptableObject
{
    private void OnEnable() => hideFlags = HideFlags.DontUnloadUnusedAsset;
    public float maxHealth = 5f;
    public float maxMana = 10f;
    public float health = 5f;
    public float mana = 10f;
    public float speed = 7f;
    public int spell = 0;

    public float jump = 15f;
    public float healthLossMultiplier = 1f;
    public float manaRecovery = 0.000001f;

}
