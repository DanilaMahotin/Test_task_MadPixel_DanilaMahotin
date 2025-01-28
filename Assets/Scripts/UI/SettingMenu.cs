using Game.Audio;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace Game.UI {
    public class SettingMenu :MenuWindow {

        [SerializeField] InGameUIManager inGameUIManager;

      
        [SerializeField] Button restartButton;
        [SerializeField] Button backToMenuButton;


        [SerializeField] Button okButton;
        [SerializeField] Button closeButton;
        [Header("music")]
        [SerializeField] Button musicButton;
        [SerializeField] Image musicOff;
        [SerializeField] Image musicOn;
        AudioSwitcher _audioManager;

        public override void Init(bool isOpen = false) {
            base.Init(isOpen);
            okButton.onClick.AddListener(CloseSettingMenu);
            closeButton.onClick.AddListener(CloseSettingMenu);

            restartButton.onClick.AddListener(RestartGame);
            backToMenuButton.onClick.AddListener(BackToMenu);
            musicButton.onClick.AddListener(ChangeMusic);

            _audioManager = GameObject.Find("AudioManager").GetComponent<AudioSwitcher>();
            musicOff.gameObject.SetActive(_audioManager.isMusicPlay);
            musicOn.gameObject.SetActive(!_audioManager.isMusicPlay);
        }

        private void CloseSettingMenu() => inGameUIManager.CloseSetting();
        private void RestartGame() => inGameUIManager.inGameManager.RestartGame();
        private void BackToMenu() => inGameUIManager.inGameManager.BackToMenu();
        private void ChangeMusic() {
            if (musicOff.gameObject.activeSelf) MusicSwitcher(false);
            else MusicSwitcher(true);
        }

        private void MusicSwitcher(bool value) {
            musicOff.gameObject.SetActive(value);
            musicOn.gameObject.SetActive(!value);
            
            _audioManager.SwitchVolume(value);
        }

    }
}