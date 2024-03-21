using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/FirstEnemySo")]
public class FirstEnemySO : ScriptableObject
{
    public float maxHealth = 20;
    public float health;
}
