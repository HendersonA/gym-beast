using UnityEngine;

namespace PowerUp
{
    [CreateAssetMenu(menuName = "Gym Beast/ColorPowerUp")]
    public class ColorPowerUp : PowerUpEffect
    {
        public Color Color;

        public override void Apply(GameObject target)
        {
            target.GetComponentInChildren<SkinnedMeshRenderer>().material.color = Color;
        }
    }
}