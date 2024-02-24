using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UHUY.DefenseBasic
{
    public class GameManager : MonoBehaviour, IComponentChecking
    {
        public float spawnTime;
        public Enemy[] enemiePrefabs;
        private bool m_isGameover;
        private int m_score;
        public GUIManager guiMng;

        public int Score { get => m_score; set => m_score = value; }

        // Start is called before the first frame update
        void Start()
        {
            
            if (IsComponentNull()) return;

            guiMng.ShowGameGUI(false);
            guiMng.UpdateMianCoins();

        }

        public void PlayGame()
        {

            guiMng.ShowGameGUI(true);
            StartCoroutine(SpawnEnemy());
            guiMng.UpdateGameplayCoins();
        }

        public bool IsComponentNull()
        {
            return guiMng == null;
        }

        public void Gameover()
        {
            if (m_isGameover) return;

            m_isGameover = true;

            Pref.bestscore = m_score;
            if(guiMng.gameoverDialog)
            guiMng.gameoverDialog.Show(true);
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
