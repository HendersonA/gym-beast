using UnityEngine;

namespace Ragdoll
{
    public class Ragdoll : MonoBehaviour, IRagdoll
    {
        public Rigidbody BoneHips { get => boneHips; }
        [SerializeField] private Rigidbody boneHips;
        private Rigidbody _mainRigidbody;
        private Animator _animator;
        private Collider[] _allCollider;

        private void Awake()
        {
            _mainRigidbody = GetComponent<Rigidbody>();
            _animator = GetComponent<Animator>();
            _allCollider = GetComponentsInChildren<Collider>();
        }

        private void OnEnable()
        {
            EnableRagdoll(false);
        }

        public void EnableRagdoll(bool isRagdoll)
        {
            for (int i = 1; i < _allCollider.Length; i++)
            {
                _allCollider[i].enabled = isRagdoll;
                _mainRigidbody.useGravity = !isRagdoll;
                _animator.enabled = !isRagdoll;
            }
        }

        public void ResetArmaturePosition()
        {
            boneHips.isKinematic = true;
            boneHips.transform.position = _mainRigidbody.transform.position;
        }

        public void OriginArmaturePosition()
        {
            boneHips.isKinematic = false;
            boneHips.transform.position = Vector3.zero;
            transform.position = Vector3.zero;

        }
    }
}