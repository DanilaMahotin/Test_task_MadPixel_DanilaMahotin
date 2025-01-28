using UnityEngine;
using System;
namespace Game.Audio {
    public class AudioSwitcher :MonoBehaviour {

        public static AudioSwitcher Instance;
        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
                Destroy(gameObject);
        }

        public void SwitchVolume(bool value) {
            AudioListener.volume = Convert.ToInt32(value);
        }
    }
}