using UnityEngine;

public abstract class PowerupEffect : ScriptableObject
{
    public int Cost;
    public abstract void Apply(GameObject target);
}