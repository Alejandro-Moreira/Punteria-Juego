using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab;
    private List<GameObject> activeEnemies = new List<GameObject>();

    void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            GameObject newEnemy = Instantiate(enemyPrefab, new Vector3(i * 2, 1, 0), Quaternion.identity);
            newEnemy.tag = "Enemy";
            activeEnemies.Add(newEnemy);
        }
    }

    void Update()
    {
    }
}
