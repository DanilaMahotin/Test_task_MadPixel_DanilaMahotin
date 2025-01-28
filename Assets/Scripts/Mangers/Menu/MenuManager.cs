using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Game.CubeNS;
namespace Menu {
    public class MenuManager :MonoBehaviour {
        [SerializeField] MenuUIManager menuUIManager;

        [HideInInspector] public List<GameObject> collisionCube;
        [SerializeField] List<MenuCube> menuCubesList;

        private void Awake() {
            Init();
            menuUIManager.Init();
        }
        private void Init() {
            int i = 0;
            while (i < menuCubesList.Count) {
                menuCubesList[i].FoundManager(this);
                i++;
            }
        }
        private void Update() {
            if (collisionCube.Count > 0) {
                MenuCube localCub = collisionCube[0].GetComponent<MenuCube>();
                localCub.currIntOfArr++;
                localCub.SetNewParam();
                int i = 1;
                do {
                    collisionCube[i].gameObject.SetActive(false);
                    i++;
                }
                while (i < collisionCube.Count);
                collisionCube.Clear();
            }
        }

        public void PlayGame() => ChangeScene(1);

        private void ChangeScene(int i) => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + i);
    }
}