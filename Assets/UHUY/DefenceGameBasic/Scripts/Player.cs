using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UHUY.DefenseBasic
{
    public class Player : MonoBehaviour, IComponentChecking
    {
        public float atkRate;
        private Animator m_anim;
        private float m_curAtkRate;
        private bool m_isAttacked;

        private void Awake()
        {
            m_anim = GetComponent<Animator>();
            m_curAtkRate = atkRate;
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        public bool IsComponentNull()
        {
            return m_anim == null;
        }

        // Update is called once per frame
        void Update()
        {
            if (IsComponentNull()) return;
                                  
            if (Input.GetMouseButtonDown(0) && !m_isAttacked)
            {

                m_anim.SetBool(Const.ATTACK_ANIM, true);
                m_isAttacked = true;
            }
            if (m_isAttacked)
            {
                m_curAtkRate -= Time.deltaTime;

                if (m_curAtkRate <= 0)
                {
                    m_isAttacked = false;
                    m_curAtkRate = atkRate;
                }
            }
        }

        public void ResetAtkAmin()
        {
            if (IsComponentNull()) return;
            m_anim.SetBool(Const.ATTACK_ANIM, false);
        }
    }
}