using UnityEngine;

public class EnemyController : MonoBehaviour, IEnemy
{
    [SerializeField] private EnemyConfig enemyConfig;
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
        _allCollider = GetComponentsInChildren<Collider>(true);
    }

    private void OnDisable()
    {
        _score.IncreaseScore(enemyConfig.Score);
    }

    public void OnDeath()
    {
        ActiveRagdoll();
        _isEnemyDead = true;
        enabled = false;
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

    private void ActiveRagdoll()
    {
        EnableRagdoll(true);
    }

    private void EnableRagdoll(bool isRagdoll)
    {
        foreach (var collider in _allCollider)
        {
            collider.enabled = isRagdoll;
            _rigidbodyEnemy.useGravity = !isRagdoll;
            _animator.enabled = !isRagdoll;
        }
    }
}
