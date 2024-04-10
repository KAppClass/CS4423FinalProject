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

    public float secondOriginalHealth;
    public float secondHealth;
    public float secondMana;
    public float secondMaxMana;

    public float thirdOriginalHealth;
    public float thirdHealth;
    public float thirdMana;
    public float thirdMaxMana;
}
