using UnityEngine;

public class EnemyController : MonoBehaviour, IEnemy
{
    private Rigidbody _rigidbodyEnemy;
    private Animator _animator;
    private Collider _mainCollider;
    private Collider[] _allCollider;
    private bool _isEnemyDead = false;
    private bool _isEnemyStacked = false;
    public bool Stacked { get => _isEnemyStacked; set => _isEnemyStacked = value; }

    private void Awake()
    {
        _rigidbodyEnemy = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
        _mainCollider = GetComponent<Collider>();
        _allCollider = GetComponentsInChildren<Collider>(true);
    }

    public void OnDeath()
    {
        ActiveRagdoll();
        _isEnemyDead = true;
        enabled = false;
    }

    private void ActiveRagdoll()
    {
        EnableRagdoll(true);
    }

    private void EnableRagdoll(bool isRagdoll)
    {
        foreach (var collider in _allCollider)
        {
            collider.enabled = isRagdoll;
            // _mainCollider.enabled = !isRagdoll;
            _rigidbodyEnemy.useGravity = !isRagdoll;
            _animator.enabled = !isRagdoll;
        }
    }

    public bool isDead()
    {
        return _isEnemyDead;
    }
}
