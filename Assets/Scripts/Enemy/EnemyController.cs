using UnityEngine;

public class EnemyController : MonoBehaviour, IEnemy
{
    private ScoreManager _score;
    private Rigidbody _rigidbodyEnemy;
    private Animator _animator;
    private Collider[] _allCollider;
    private bool _isEnemyDead = false;
    private bool _isEnemyStacked = false;
    public bool Stacked
    {
        get => _isEnemyStacked;
        set => _isEnemyStacked = value;
    }

    private void Awake()
    {
        _score = FindObjectOfType<ScoreManager>();
        _rigidbodyEnemy = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
        _allCollider = GetComponentsInChildren<Collider>();
    }

    private void OnEnable()
    {
        OnAlive();
    }

    public void OnDeath()
    {
        EnableRagdoll(true);
        _isEnemyDead = true;
        enabled = false;
    }

    private void OnAlive()
    {
        EnableRagdoll(false);
        _isEnemyDead = false;
        enabled = true;
    }

    public bool isDead()
    {
        return _isEnemyDead;
    }

    public void SetPosition(Transform newTransform)
    {
        this.transform.position = newTransform.position;
        this.transform.SetParent(newTransform);
    }

    private void EnableRagdoll(bool isRagdoll)
    {
        for (int i = 1; i < _allCollider.Length; i++)
        {
            _allCollider[i].enabled = isRagdoll;
            _rigidbodyEnemy.useGravity = !isRagdoll;
            _animator.enabled = !isRagdoll;
        }
    }
}
