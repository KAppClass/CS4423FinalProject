using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/EnemySo")]
public class EnemySO : ScriptableObject
{
    public float firstOriginalHealth;
    public float firstOriginalMana;
    public float firstHealth;
    public float firstMana;
    public float firstMaxMana;
    public float firstSpeed;
    public float firstShootTime;

    public float secondOriginalHealth;
    public float secondOriginalMana;
    public float secondHealth;
    public float secondMana;
    public float secondMaxMana;
    public float secondSpeed;
    public float secondShootTime;

    public float thirdOriginalHealth;
    public float thirdOriginalMana;
    public float thirdHealth;
    public float thirdMana;
    public float thirdMaxMana;
    public float thirdSpeed;
    public float thirdShootTime;
}
