using UnityEngine;

namespace Ragdoll
{
    public interface IRagdoll
    {
        Rigidbody BoneHips { get; }
        void EnableRagdoll(bool isRagdoll);
        void ResetArmaturePosition();
    }
}
