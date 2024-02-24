using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


namespace UHUY.DefenseBasic
{
    public class GameoverDialog : Dialog
    {
        public Text bestScoreTxt;

        public override void Show(bool isShow)
        {
            base.Show(isShow);

            if(bestScoreTxt)
                bestScoreTxt.text = Pref.bestscore.ToString("0000");
        }

        public void Replay()
        {
            Close();
            SceneManager.LoadScene(Const.GAMEPLAY_SCENE);
        }

        public void QuitGame()
        {
            Application.Quit();
        }
    }
}

