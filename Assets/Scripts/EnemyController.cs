using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour, IEnemy
{

    private bool isEnemyDead = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnDeath()
    {
        ActiveRagdoll();
        isEnemyDead = true;
        enabled = false;
    }

    private void ActiveRagdoll()
    {

    }

    public bool isDead()
    {
        return isEnemyDead;
    }
}
