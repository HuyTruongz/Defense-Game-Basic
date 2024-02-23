using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UHUY.DefenseBasic
{
    public class Enemy : MonoBehaviour,IComponentChecking
    {
        private Animator m_anim;
        private Rigidbody2D m_rb;
        public float speed;
        public float atkDistance;
        public int minCoinBonus;
        public int maxCoinBonus;

        private Player m_player;
        private bool m_isDead;

        private GameManager m_gm;


        private void Awake()
        {
            m_anim = GetComponent<Animator>();
            m_rb = GetComponent<Rigidbody2D>();
            m_player = FindObjectOfType<Player>();
            m_gm = FindObjectOfType<GameManager>();
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        public bool IsComponentNull()
        {
            return m_anim == null || m_rb == null || m_player == null || m_gm == null ;
        }

        // Update is called once per frame
        void Update()
        {
            if (IsComponentNull()) return;

            float distToPlayer = Vector2.Distance(m_player.transform.position, transform.position);

            if (distToPlayer <= atkDistance)
            {
                if (m_anim)
                {
                    m_anim.SetBool(Const.ATTACK_ANIM, true);
                }
                m_rb.velocity = Vector2.zero;
            }
            else
            {
                m_rb.velocity = new Vector2(-speed, m_rb.velocity.y);
            }
        }
        public void Die()
        {
            if (IsComponentNull() || m_isDead) return;

            m_isDead = true;
            m_anim.SetTrigger(Const.DEAD_ANIM);
            m_rb.velocity = Vector2.zero;
            gameObject.layer = LayerMask.NameToLayer(Const.DEAD_ANIM);
            
            m_gm.Score++;
            int coinBonus = Random.Range(minCoinBonus, maxCoinBonus);
            Debug.Log(coinBonus);
            Pref.coins += coinBonus;


            Destroy(gameObject, 2f);
        }
    }
}

