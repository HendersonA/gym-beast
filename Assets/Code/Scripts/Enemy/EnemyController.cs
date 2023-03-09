using UnityEngine;
using Ragdoll;

namespace Enemy
{
    public class EnemyController : MonoBehaviour, IEnemy
    {
        private Animator _animator;
        private IRagdoll _ragdoll;
        private bool _isEnemyDead = false;
        public bool IsStacked { get; set; }
        public bool CanStack { get; set; }

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _ragdoll = GetComponent<IRagdoll>();
        }

        private void OnEnable()
        {
            if (_isEnemyDead)
                OnAlive();
        }

        public void OnDeath()
        {
            _ragdoll.EnableRagdoll(true);
            _isEnemyDead = true;
        }

        public void OnAlive()
        {
            _ragdoll.EnableRagdoll(false);
            _ragdoll.OriginArmaturePosition();
            _isEnemyDead = false;
            IsStacked = false;
            CanStack = false;
        }

        public bool isDead()
        {
            return _isEnemyDead;
        }
    }
}