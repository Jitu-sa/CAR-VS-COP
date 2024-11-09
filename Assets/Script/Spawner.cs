using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject EnemyPrefab;
    [SerializeField] int PoolSize = 2;
    [SerializeField] float SpawnTimer = 1f;
    GameObject Target;

    GameObject[] Pool;

    void Awake()
    {
        PopulatePool();
        Target = GameObject.FindWithTag("Player");
    }

    void OnEnable()
    {
        StartCoroutine(SpawnEnemy());
    }

    void PopulatePool()
    {
        Pool = new GameObject[PoolSize];

        for (int i = 0; i < Pool.Length; i++)
        {
            Pool[i] = Instantiate(EnemyPrefab, this.transform);
            Pool[i].SetActive(false);
        }
    }

    void EnableObjectInPool()
    {
        for (int i = 0; i < Pool.Length; i++)
        {
            if (!Pool[i].activeInHierarchy)
            {
                float xpos = Random.Range(-2, 2.1f), ypos = Random.Range(0, 2) == 0 ? 6 : -6;
                Pool[i].transform.position = new Vector3(Target.transform.position.x + xpos, Target.transform.position.y + ypos, 0);
                Pool[i].SetActive(true);
                return;
            }
        }
    }

    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            EnableObjectInPool();
            yield return new WaitForSeconds(SpawnTimer);
        }
    }
}
