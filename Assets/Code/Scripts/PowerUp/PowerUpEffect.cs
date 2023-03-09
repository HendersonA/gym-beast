using UnityEngine;

namespace PowerUp
{
    public abstract class PowerUpEffect : ScriptableObject
    {
        public int Cost;
        public abstract void Apply(GameObject target);
    }
}