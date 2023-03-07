using UnityEngine;

public interface IEnemy
{
    void OnDeath();
    bool isDead();
    bool Stacked { get; set; }
    void SetPosition(Transform newTransform);
}