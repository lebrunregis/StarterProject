﻿using UnityEngine;

namespace Gamekit3D
{
    [ExecuteInEditMode]
    public class WaterRipple : MonoBehaviour
    {

        private Material mat;
        public Transform offsetPos;

        // Use this for initialization
        private void Start()
        {
            mat = GetComponent<MeshRenderer>().material;
        }

        // Update is called once per frame
        private void Update()
        {
            mat.SetVector("_UVOffset", new Vector4(offsetPos.position.x, 0, offsetPos.position.z, 1));
        }
    }
}
