﻿using UnityEngine;

namespace Gamekit3D
{
    [ExecuteInEditMode]
    public class SunSkybox : MonoBehaviour
    {
        public Material skyboxMaterial;
        private int sunDirId, sunColorId;
        private Light sun;

        private void Awake()
        {
            sun = GetComponent<Light>();
            sunDirId = Shader.PropertyToID("_SunDirection");
            sunColorId = Shader.PropertyToID("_SunColor");
        }

        private void Update()
        {
            if (skyboxMaterial)
            {
                skyboxMaterial.SetVector(sunDirId, -transform.forward.normalized);
                skyboxMaterial.SetColor(sunColorId, sun.color);
            }
        }
    }
}