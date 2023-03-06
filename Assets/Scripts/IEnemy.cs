public interface IEnemy
{
    void OnDeath();
    bool isDead();
    bool Stacked { get; set; }
}