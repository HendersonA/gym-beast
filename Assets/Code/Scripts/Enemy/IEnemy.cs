using UnityEngine;

namespace Enemy
{
    public interface IEnemy
    {
        GameObject gameObject { get; }
        void OnDeath();
        bool isDead();
        bool IsStacked { get; set; }
        bool CanStack { get; set; }
    }
}