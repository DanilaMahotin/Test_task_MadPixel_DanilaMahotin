using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
namespace Game.UI {
    public class InGameUi :MenuWindow {

        [SerializeField] InGameUIManager inGameUIManager;
        [SerializeField] Button settingButton;
        [SerializeField] TextMeshProUGUI currScoreText;
        [SerializeField] TextMeshProUGUI recordScoreText;

        public override void Init(bool isOpen = false) {
            base.Init(isOpen);
            settingButton.onClick.AddListener(OpenSetting);
        }

        private void OpenSetting() => inGameUIManager.OpenSetting();

        public void SetScore(int score, int hightScore) {
            currScoreText.text = score.ToString();
            recordScoreText.text = "Hight score: " + hightScore.ToString();
        }
    }
}