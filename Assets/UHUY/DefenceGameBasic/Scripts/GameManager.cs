using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UHUY.DefenseBasic
{
    public class GameManager : MonoBehaviour
    {
        public float spawnTime;
        public Enemy[] enemiePrefabs;
        private bool m_isGameover;
        // Start is called before the first frame update
        void Start()
        {
            StartCoroutine(SpawnEnemy());
        }

        // Update is called once per frame
        void Update()
        {

        }

        IEnumerator SpawnEnemy()
        {
            while (!m_isGameover)
            {
                if (enemiePrefabs != null && enemiePrefabs.Length > 0)
                {
                    int randIdx = Random.Range(0, enemiePrefabs.Length);
                    Enemy enemyPrefab = enemiePrefabs[randIdx];

                    if (enemyPrefab)
                    {
                        Instantiate(enemyPrefab, new Vector3(8, 0, 0), Quaternion.identity);
                    }
                }

                yield return new WaitForSeconds(spawnTime);
            }
        }
    }
}
