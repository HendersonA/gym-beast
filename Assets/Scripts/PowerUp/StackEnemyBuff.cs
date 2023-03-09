using UnityEngine;

namespace PowerUps
{
    [CreateAssetMenu(menuName = "Gym Beast/StackEnemyBuff")]
    public class StackEnemyBuff : PowerupEffect
    {
        public int amount;

        public override void Apply(GameObject target)
        {
            target.GetComponent<StackAbility>().SetLimitStack(amount);
        }
    }
}