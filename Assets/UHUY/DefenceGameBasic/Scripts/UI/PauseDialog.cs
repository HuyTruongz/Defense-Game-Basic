using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace UHUY.DefenseBasic
{
    public class PauseDialog : Dialog
    {
        public override void Show(bool isShow)
        {
            Time.timeScale = 0f;

            base.Show(isShow);
        }

        public void Resume()
        {
            Close();
        }

        public void Replay()
        {
            Close();
            SceneManager.LoadScene(Const.GAMEPLAY_SCENE);
        }

        public override void Close()
        {
            Time.timeScale = 1f;
            base.Close();
        }
    }
}

