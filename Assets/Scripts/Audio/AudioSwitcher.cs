using UnityEngine;
using System;
namespace Game.Audio {
    public class AudioSwitcher :MonoBehaviour {

        public static AudioSwitcher Instance;
        public bool isMusicPlay;
        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
                LoadVolumeSetting();
            }
            else
                Destroy(gameObject);
        }

        public void SwitchVolume(bool value) {
            AudioListener.volume = Convert.ToInt32(value);
            isMusicPlay = value;
            SaveVolumeSetting();
        }
        private void SaveVolumeSetting() 
        {
            PlayerPrefs.SetInt("isMusicPlay", isMusicPlay ? 1:0);
            PlayerPrefs.Save();
        }

        private void LoadVolumeSetting() 
        {
            if (PlayerPrefs.HasKey("isMusicPlay")) 
            {
                isMusicPlay = PlayerPrefs.GetInt("isMusicPlay") == 1;
                AudioListener.volume = isMusicPlay ? 1 : 0;
            }
        }
    }
}