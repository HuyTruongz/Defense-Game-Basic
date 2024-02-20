using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UHUY.DefenseBasic
{
    public class ShopManager : MonoBehaviour
    {
        public ShopItem[] items;
        // Start is called before the first frame update
        void Start()
        {
            Init();
        }

        private void Init()
        {
            if (items == null || items.Length <= 0) return;

            for (int i = 0; i < items.Length; i++)
            {
                var item = items[i];

                if(item != null)
                {
                    string dataKey = Const.PLAYER_PREFIX_PREF + i;
                    if(i == 0)
                    {
                        Pref.SetBool(dataKey,true);
                    }
                    else
                    {
                        if (!PlayerPrefs.HasKey(dataKey))
                        {
                            Pref.SetBool(dataKey, false);
                        }
                    }
                }
            }
        }
    }
}
