using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Game.CubeNS {
    public class Cube :BaseCube {
        [SerializeField] InGameManager inGameManager;


        public bool IsPushed {
            set { isPushed = value; }
            get { return isPushed; }
        }
        private bool isPushed = false;

        public void StartCoroutinePushed(float time) => StartCoroutine(PushedChange(time));

        private IEnumerator PushedChange(float time) {
            yield return new WaitForSeconds(time);
            IsPushed = true;
        }
        protected override void SetValueToManagerList() {
            if(inGameManager.collisionCube.Count < 2)
            inGameManager.collisionCube.Add(this.gameObject);
        }


        private void Update() {
            if (inGameManager.IsGameOver) return;
            if(IsPushed == true && transform.position.z < inGameManager.Boards.z) {
                inGameManager.GameOver();
            }

            if(transform.position.x > inGameManager.Boards.x) transform.position
                = new Vector3(inGameManager.Boards.x, transform.position.y, transform.position.z);
            else if(transform.position.x < -inGameManager.Boards.x) transform.position
                 = new Vector3(-inGameManager.Boards.x, transform.position.y, transform.position.z);
            if(transform.position.z > inGameManager.Boards.y) transform.position
                 = new Vector3(transform.position.x, transform.position.y, inGameManager.Boards.y);

            
        }

        
        public void FoundManager(InGameManager inGame) {
            inGameManager = inGame;
        }

       
    }
}