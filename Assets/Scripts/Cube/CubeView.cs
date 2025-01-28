using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
namespace Game.CubeNS {
    public class CubeView :MonoBehaviour {
        [SerializeField] List<TextMeshProUGUI> cubeNum;
        [SerializeField] CubeInfo cubeInfo;
        [SerializeField] MeshRenderer meshRenderer;

        public void Init() {
            if (meshRenderer == null) meshRenderer = GetComponent<MeshRenderer>();
        }

        public void SetNewParam(int currIntOfArr) {
            int currNum = (int)Mathf.Pow(2, currIntOfArr + 1);
            int i = 0;
            while (i < cubeNum.Count) {
                cubeNum[i].text = currNum.ToString();
                i++;
            }
            if (currIntOfArr > cubeInfo.colorsOfCube.Count - 1) {
                currIntOfArr = cubeInfo.colorsOfCube.Count - 1;
            }
            meshRenderer.material = cubeInfo.colorsOfCube[currIntOfArr];
        }
    }
}