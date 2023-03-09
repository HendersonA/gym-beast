using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using Inertia;
using Ragdoll;
using Enemy;

namespace Stack
{
    public class StackAbility : MonoBehaviour
    {
        public event Action<int> OnStacked;
        [SerializeField] private Transform targetToStack;
        [SerializeField] private float heightBetweenTransform = 0.6f;
        [SerializeField] private int limitStack = 2;
        public int LimitStack { get => limitStack; }
        private List<GameObject> _enemyList = new List<GameObject>();
        private Vector3 _enemyPosition;
        private Vector3 _currentEnemyPosition;
        private int _enemyListIndexCounter = 0;

        private void Start()
        {
            OnStacked?.Invoke(_enemyList.Count);
        }

        public void UnloadStack()
        {
            for (int i = 0; i < _enemyList.Count; i++)
            {
                _enemyList[i].gameObject.SetActive(false);
            }
            _enemyList.Clear();
            OnStacked?.Invoke(_enemyList.Count);
        }

        public void SetLimitStack(int newValue)
        {
            limitStack += newValue;
            OnStacked?.Invoke(_enemyList.Count);
        }

        private void CheckAmountBeforeStack(GameObject enemyGameobject)
        {
            if (_enemyList.Count < limitStack)
            {
                Collider enemyCollider = enemyGameobject.GetComponent<Collider>();
                if (_enemyList.Count == 0)
                {
                    FirstStack(enemyCollider);
                }
                else if (_enemyList.Count >= 1)
                {
                    MoreStack(enemyCollider);
                }
                _enemyList.Add(enemyGameobject);
            }
        }

        private void FirstStack(Collider collider)
        {
            _enemyPosition = targetToStack.position;
            _currentEnemyPosition = new Vector3(collider.transform.position.x, _enemyPosition.y, collider.transform.position.z);
            collider.gameObject.transform.position = _currentEnemyPosition;
            _currentEnemyPosition = new Vector3(collider.transform.position.x, transform.position.y + 0.3f, collider.transform.position.z);
            collider.gameObject.GetComponentInParent<InertiaScript>().UpdatePosition(transform, true);
        }

        private void MoreStack(Collider collider)
        {
            _enemyPosition = _enemyList.Last().transform.position + new Vector3(0f, heightBetweenTransform, 0f);
            _currentEnemyPosition = new Vector3(collider.transform.position.x, _enemyPosition.y, collider.transform.position.z);
            collider.gameObject.transform.position = _currentEnemyPosition;
            _currentEnemyPosition = new Vector3(collider.transform.position.x, transform.position.y + 0.3f, collider.transform.position.z);
            collider.gameObject.GetComponentInParent<InertiaScript>().UpdatePosition(_enemyList[_enemyListIndexCounter].transform, true);
        }

        private bool CanStack(IEnemy enemy)
        {
            return enemy != null && enemy.isDead() && !enemy.IsStacked && enemy.CanStack;
        }

        private void OnTriggerEnter(Collider other)
        {
            IEnemy enemy = other.GetComponentInParent<IEnemy>();
            IRagdoll ragdoll = other.GetComponentInParent<IRagdoll>();

            if (CanStack(enemy) && other.GetComponent<Rigidbody>().Equals(ragdoll.BoneHips))
            {
                enemy.IsStacked = true;
                ragdoll.ResetArmaturePosition();
                CheckAmountBeforeStack(enemy.gameObject);
                OnStacked?.Invoke(_enemyList.Count);
            }
        }
    }
}