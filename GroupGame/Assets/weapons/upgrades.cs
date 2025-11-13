using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Upgrades", menuName = "ScriptableObjects/Upgrades", order = 1)]

public class Upgrades : ScriptableObject
{
    public string Upgrading;
    public int pricing;

    public int HealthValue;
    public int DamageValue;
    public int MoneyValue;
}
