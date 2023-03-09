using System;
using UnityEngine;
using UnityEditor;

public class EnemyController : MonoBehaviour, IEnemy
{
    public Rigidbody BoneHips;
    private Rigidbody _mainRigidbody;
    private Animator _animator;
    private Collider[] _allCollider;
    private bool _isEnemyDead = false;
    public bool IsStacked { get; set; }
    public bool CanStack { get; set; }

    [SerializeField] private int force = 10;

    private void Awake()
    {
        _mainRigidbody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
        _allCollider = GetComponentsInChildren<Collider>();
    }

    private void OnEnable()
    {
        OnAlive();
        IsStacked = false;
        CanStack = false;
    }

    [ContextMenu("Ragdoll")]
    public void OnDeath()
    {
        EnableRagdoll(true);
        _isEnemyDead = true;
    }

    private void OnAlive()
    {
        EnableRagdoll(false);
        _isEnemyDead = false;
        IsStacked = false;
    }

    public bool isDead()
    {
        return _isEnemyDead;
    }

    private void EnableRagdoll(bool isRagdoll)
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
        IsStacked = true;
        BoneHips.isKinematic = true;
        BoneHips.transform.position = _mainRigidbody.transform.position;
    }
}
