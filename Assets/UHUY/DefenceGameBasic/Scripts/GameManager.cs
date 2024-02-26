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
        private Player m_curPlayer;
        public ShopManager shopMng;

        public int Score { get => m_score; set => m_score = value; }

        // Start is called before the first frame update
        void Start()
        {
            
            if (IsComponentNull()) return;

            guiMng.ShowGameGUI(false);
            guiMng.UpdateMianCoins();

        }

        public bool IsComponentNull()
        {
            return guiMng == null || shopMng == null;
        }

        public void PlayGame()
        {
            ActivePlayer();

            guiMng.ShowGameGUI(true);
            StartCoroutine(SpawnEnemy());
            guiMng.UpdateGameplayCoins();


        }

        public void ActivePlayer()
        {
            if (IsComponentNull()) return;

            if (m_curPlayer)
            {
                Destroy(m_curPlayer.gameObject);
            }

            var shopItems = shopMng.items;

            if (shopItems == null || shopItems.Length <= 0) return;

            var newPlayerPb = shopItems[Pref.curPlayerId].playerPreFab;

            if (newPlayerPb)
            {
                m_curPlayer = Instantiate(newPlayerPb, new Vector3(-7f, -1f, 0f), Quaternion.identity);
            }
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
