using UnityEngine;
using System;
namespace Game.Audio {
    public class AudioSwitcher :MonoBehaviour {
        
        public void SwitchVolume(bool value) {
            AudioListener.volume = Convert.ToInt32(value);
        }
    }
}