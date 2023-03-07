using UnityEngine;

public class StackEnemy : MonoBehaviour
{
    [SerializeField] private Transform shoulder;
    private int _countStackedEnemy;

    public int UnloadStack()
    {
        _countStackedEnemy = 0;

        for (int i = 0; i < shoulder.childCount; i++)
        {
            CountScore(shoulder.GetChild(i).GetComponent<EnemyController>().enemyConfig.Score);
            shoulder.GetChild(i).gameObject.SetActive(false);
            shoulder.GetChild(i).transform.SetParent(transform.parent);
        }
        return _countStackedEnemy;
    }

    private void CountScore(int score)
    {
        _countStackedEnemy += score;
    }

    private void Stack(IEnemy enemy)
    {
        enemy.Stacked = true;
        enemy.SetPosition(shoulder);
    }

    private void OnTriggerEnter(Collider other)
    {
        IEnemy enemy = other.GetComponent<IEnemy>();
        if (enemy != null && enemy.isDead() && !enemy.Stacked)
        {
            Stack(enemy);
        }
    }
}