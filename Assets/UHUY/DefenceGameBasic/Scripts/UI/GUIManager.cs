using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace UHUY.DefenseBasic
{
    public class GUIManager : MonoBehaviour
    {
        public GameObject homeGUI;
        public GameObject gameGUI;
        public Dialog gameoverDialog;
        public Text mainCoinTxt;
        public Text gameplayCoinTxt;


        void Start()
        {

        }

        public void ShowGameGUI(bool isShow)
        {
            if(gameGUI)
                gameGUI.SetActive(isShow);
            if(homeGUI)
                homeGUI.SetActive(!isShow);
        }

        public void UpdateMianCoins()
        {
            if(mainCoinTxt)
                mainCoinTxt.text = Pref.coins.ToString();
        }

        public void UpdateGameplayCoins()
        {
            if (gameplayCoinTxt)
                gameplayCoinTxt.text = Pref.coins.ToString();
        }
    }
}

