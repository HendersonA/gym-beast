using UnityEngine;
using Stack;

namespace PowerUp
{
    [CreateAssetMenu(menuName = "Gym Beast/StackPowerUp")]
    public class StackPowerUp : PowerUpEffect
    {
        public int Amount;

        public override void Apply(GameObject target)
        {
            target.GetComponent<StackAbility>().SetLimitStack(Amount);
        }
    }
}