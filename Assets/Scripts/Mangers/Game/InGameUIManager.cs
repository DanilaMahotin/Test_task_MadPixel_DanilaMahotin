using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.UI;
namespace Game {
    public class InGameUIManager :MonoBehaviour {
        public InGameManager inGameManager;
        [Header("UI Managers")]
        public InputManager inputManager;
        public InGameUi inGameUi;
        public SettingMenu settingMenu;
        public GameOver gameOver;
        public void Init() {
            inputManager.Init(this);
            inGameUi.Init(true);
            settingMenu.Init(false);
            gameOver.Init(false);
        }

        public void OpenSetting() {
            inputManager.Waintig = true;

            inGameUi.Close();
            settingMenu.Open();
            gameOver.Close();
        }
        public void CloseSetting() {
            inputManager.Waintig = false;

            inGameUi.Open();
            settingMenu.Close();
            gameOver.Close();
        }

        public void GameOver() {
            inputManager.Waintig = true;

            inGameUi.Close();
            settingMenu.Close();
            gameOver.Open();

            gameOver.gameOverAudio.Play();

        }
    }
}