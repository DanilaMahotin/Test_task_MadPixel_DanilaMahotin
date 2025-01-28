using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace Game.UI {
    public class GameOver :MenuWindow {
        [SerializeField] InGameUIManager inGameUIManager;


        [SerializeField] Button restartButton;
        [SerializeField] Button backToMenuButton;

        public AudioSource gameOverAudio;

        public override void Init(bool isOpen = false) {
            base.Init(isOpen);
            restartButton.onClick.AddListener(RestartGame);
            backToMenuButton.onClick.AddListener(BackToMenu);
        }

        private void RestartGame() => inGameUIManager.inGameManager.RestartGame();
        private void BackToMenu() => inGameUIManager.inGameManager.BackToMenu();
    }
}