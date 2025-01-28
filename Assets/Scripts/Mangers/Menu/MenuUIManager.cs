using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using YG;
using PlayerPrefs = RedefineYG.PlayerPrefs;
namespace Menu {
    public class MenuUIManager :MonoBehaviour {

        public MenuManager menuManager;
        public Localization localiz;
        public int language;
        [SerializeField] Button playGameButton;
        [SerializeField] Button languageButton;
        public void Init() {
            language = PlayerPrefs.GetInt("language", language);
            playGameButton.onClick.AddListener(PlayGame);
            languageButton.onClick.AddListener(Changelanguage);
        }

        private void PlayGame() 
        {
            if (YG2.isTimerAdvCompleted)
                YG2.InterstitialAdvShow();
            else 
                menuManager.PlayGame();
                
                
        }
        private void Changelanguage() 
        {
            if (language == 0)
            {
                language = 1;
                PlayerPrefs.SetInt("language", language);
                PlayerPrefs.Save();
                localiz.UpdateText();
            }
            else 
            {
                language = 0;
                PlayerPrefs.SetInt("language", language);
                PlayerPrefs.Save();
                localiz.UpdateText();
            }
        }
    }
}