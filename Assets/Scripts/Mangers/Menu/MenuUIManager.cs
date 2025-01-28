using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace Menu {
    public class MenuUIManager :MonoBehaviour {

        public MenuManager menuManager;

        [SerializeField] Button playGameButton;
        public void Init() {
            playGameButton.onClick.AddListener(PlayGame);
        }

        private void PlayGame() => menuManager.PlayGame();
    }
}