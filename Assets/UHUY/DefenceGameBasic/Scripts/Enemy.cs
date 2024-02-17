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
        private Player m_player;


        private void Awake()
        {
            m_anim = GetComponent<Animator>();
            m_rb = GetComponent<Rigidbody2D>();
            m_player = FindObjectOfType<Player>();
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        public bool IsComponentNull()
        {
            return m_anim == null || m_rb == null || m_player == null ;
        }

        // Update is called once per frame
        void Update()
        {
            if (IsComponentNull()) return;

            if (Vector2.Distance(m_player.transform.position, transform.position) <= atkDistance)
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
    }
}
