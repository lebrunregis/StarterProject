using UnityEngine;
using UnityEngine.Rendering;

namespace Gamekit3D
{
    [ExecuteInEditMode]
    public class CopyShadowMap : MonoBehaviour
    {
        private CommandBuffer cb = null;

        private void OnEnable()
        {
            var light = GetComponent<Light>();
            if (light)
            {
                cb = new CommandBuffer();
                cb.name = "CopyShadowMap";
                cb.SetGlobalTexture("_DirectionalShadowMask", new RenderTargetIdentifier(BuiltinRenderTextureType.CurrentActive));
                light.AddCommandBuffer(UnityEngine.Rendering.LightEvent.AfterScreenspaceMask, cb);
            }
        }

        private void OnDisable()
        {
            var light = GetComponent<Light>();
            if (light)
            {
                light.RemoveCommandBuffer(UnityEngine.Rendering.LightEvent.AfterScreenspaceMask, cb);
            }
        }

    }
}