using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/EnemySo")]
public class EnemySO : ScriptableObject
{
    public float firstOriginalHealth;
    public float firstHealth;
    public float firstMana;
    public float firstMaxMana;
}
