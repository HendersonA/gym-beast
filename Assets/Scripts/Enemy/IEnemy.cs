using System;

public interface IEnemy
{
    void OnDeath();
    bool isDead();
    void ResetArmaturePosition();
    bool IsStacked { get; set; }
    bool CanStack { get; set; }
}