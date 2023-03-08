using UnityEngine;

namespace PowerUps
{
    [CreateAssetMenu(menuName = "Gym Beast/ColorPowerUp")]
    public class ColorPowerUp : PowerupEffect
    {
        public Color color;

        public override void Apply(GameObject target)
        {
            target.GetComponentInChildren<SkinnedMeshRenderer>().material.color = color;
        }
    }
}