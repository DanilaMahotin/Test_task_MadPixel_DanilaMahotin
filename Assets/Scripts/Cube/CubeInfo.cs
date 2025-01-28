using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Game.CubeNS {
    [CreateAssetMenu(menuName = "Cube state")]
    public class CubeInfo :ScriptableObject {
        public List<Material> colorsOfCube;
    }
}