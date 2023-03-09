using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class StackAbility : MonoBehaviour
{
    [SerializeField] private Transform shoulder;
    [SerializeField] private int limitStack = 2;
    private List<EnemyController> _enemyList = new List<EnemyController>();
    private Vector3 _firstEnemyPos;
    private Vector3 _currentEnemyPos;
    private int _enemyListIndexCounter = 0;

    public void UnloadStack()
    {
        for (int i = 0; i < _enemyList.Count; i++)
        {
            _enemyList[i].gameObject.SetActive(false);
        }
        _enemyList.Clear();
    }

    public void SetLimitStack(int newValue)
    {
        limitStack += newValue;
    }

    private void SetIntoEnemyList(EnemyController enemy)
    {
        if (_enemyList.Count < limitStack)
        {
            if (_enemyList.Count == 0)
            {
                FirstStack(enemy.GetComponent<Collider>());
            }
            else if (_enemyList.Count >= 1)
            {
                MoreStack(enemy.GetComponent<Collider>());
                _enemyListIndexCounter++;
            }
            _enemyList.Add(enemy);
        }
    }

    private void FirstStack(Collider collider)
    {
        _firstEnemyPos = shoulder.position;
        // GetComponent<MeshRenderer>().bounds.max;
        _currentEnemyPos = new Vector3(collider.transform.position.x, _firstEnemyPos.y, collider.transform.position.z);
        collider.gameObject.transform.position = _currentEnemyPos;
        _currentEnemyPos = new Vector3(collider.transform.position.x, transform.position.y + 0.3f, collider.transform.position.z);
        collider.gameObject.GetComponentInParent<Inertia>().UpdatePosition(transform, true);

    }

    //! O bug é devido sim a esta função
    //TODO Talvez seja um bug de posicionamento para ser analizado. No eixo Y
    private void MoreStack(Collider collider)
    {
        _firstEnemyPos = _enemyList.Last().transform.position + new Vector3(0f, 0.6f, 0f);
        _currentEnemyPos = new Vector3(collider.transform.position.x, _firstEnemyPos.y, collider.transform.position.z);
        collider.gameObject.transform.position = _currentEnemyPos;
        _currentEnemyPos = new Vector3(collider.transform.position.x, transform.position.y + 0.3f, collider.transform.position.z);
        collider.gameObject.GetComponentInParent<Inertia>().UpdatePosition(_enemyList[_enemyListIndexCounter].transform, true);

    }

    private bool CanStack(EnemyController enemy)
    {
        return enemy != null && enemy.isDead() && !enemy.IsStacked && enemy.CanStack;
        //! Retornar
        //
    }
    //? O outro bug pode ser corrigido separando a deteccao do colisor do hips em vez do colisor principal
    //TODO Refatorar
    //TODO Talvez transferir para o CharacterMovement e fazer parte do else para resolver o bug de após dá o soco, automaticamente stackar
    //TODO Trocar para OnColliderEnter para Colidir com o ragdoll e não mais com o capsule collider do inimigo
    //TODO Testar se o Capsule Collider do player estando com o Istrigger ativo, está bugando a lógica do próximo ragdoll colado ao próximo corpo
    private void OnTriggerEnter(Collider other)
    {
        EnemyController enemy = other.GetComponentInParent<EnemyController>();
        if (CanStack(enemy) && other.GetComponent<Rigidbody>().Equals(enemy.BoneHips))
        {
            enemy.ResetArmaturePosition();
            SetIntoEnemyList(enemy);
        }
    }
}