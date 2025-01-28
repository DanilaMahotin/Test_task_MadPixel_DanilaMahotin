using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Game.CubeNS;
using Game.Audio;
using YG;
using PlayerPrefs = RedefineYG.PlayerPrefs;
namespace Game {
    public class InGameManager :MonoBehaviour {

        public InGameUIManager inGameUIManager;
        public AudioSwitcher audioSwitcher;
        [Header("MainCube")]
        [SerializeField] GameObject cubePrefab;
        [SerializeField] private Vector3 startPosition = new Vector3(0, 0.5f, 6.20f);
        
        public GameObject CubeGO {
            get { return cube; }
        }
        private GameObject cube;
        private Cube cubeCube;

        [SerializeField] AudioSource mergeAudio;
        public float TimeToChange {
            get { return timeBetweenChangeCube; }
        }
        [SerializeField] private float timeBetweenChangeCube = 1f;
        [Header("Start Generation Prefabs")]
        [SerializeField] List<Vector3> startPositionCubes;

        [Header("Boards")]
        [SerializeField] Vector3 boards;

        [HideInInspector] public List<GameObject> collisionCube;

        public int Score {
            set { 
                score += value; 
                if(score > GetScore()) {
                    PlayerPrefs.SetInt("Score", score);
                }
                inGameUIManager.inGameUi.SetScore(score, GetScore());
            }
            get { return score; }
        }
        private int score = 0;


        private int GetScore() { return PlayerPrefs.GetInt("Score", 0); }
        public Vector3 Boards {
            get { return boards; }
        }
        private void Awake() {
            Init();
        }
        private void Init() {
            inGameUIManager.Init();
            NewCube();
            GenerateOtherCubs();

            inGameUIManager.inGameUi.SetScore(score, GetScore());
        }
        
        public void NewCube() {
            cube = InstantiateGameObjects(cubePrefab, startPosition);
            cubeCube = cube.GetComponent<Cube>();
            cubeCube.FoundManager(this);
            cubeCube.Init();
        }

        private void GenerateOtherCubs() {
            int i = 0;
            while (i < startPositionCubes.Count) {
                if (RandomBool()) {
                    GameObject gameObject = InstantiateGameObjects(cubePrefab, startPositionCubes[i]);
                    gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                    Cube localCube = gameObject.GetComponent<Cube>();
                    localCube.FoundManager(this);
                    localCube.Init();
                    localCube.IsPushed = true;
                }
                i++;
            }
        }

        private GameObject InstantiateGameObjects(GameObject gameObject, Vector3 vector) {
            return Instantiate(gameObject, vector, Quaternion.identity);
        }

        public void RechargeCubeCoroutine() => StartCoroutine(RechargeCube()); 

        private IEnumerator RechargeCube() {
            inGameUIManager.inputManager.Waintig = true;
            yield return new WaitForSeconds(timeBetweenChangeCube);
            NewCube();
            inGameUIManager.inputManager.Waintig = false;
        }
        private bool RandomBool() { return Random.value > 0.5f;}

        private void Update() {
            if(collisionCube.Count > 0) {
                Cube localCub = collisionCube[0].GetComponent<Cube>();
                localCub.currIntOfArr++;
                localCub.SetNewParam();
                Score = localCub.currNum;
                localCub.IsCollision = false;
                mergeAudio.Play();

                int i = 1;
                do {
                    Destroy(collisionCube[i]);
                    i++;
                }
                while (i < collisionCube.Count);
                collisionCube.Clear();
            }
        }


        public void GameOver() {
            isGameOver = true;
            inGameUIManager.GameOver();
        }

        public bool IsGameOver {
            get { return isGameOver; }
        }
        private bool isGameOver = false;
        public void RestartGame() 
        {
            YG2.RewardedAdvShow("rewarded", () =>
            {
                ChangeScene(1);
            });
            
        } 
        
        public void BackToMenu() 
        {
            if (YG2.isTimerAdvCompleted)
                YG2.InterstitialAdvShow();
            else 
                ChangeScene(0);
                
                
        }
        private void ChangeScene(int i) => SceneManager.LoadScene(i);
    }
}