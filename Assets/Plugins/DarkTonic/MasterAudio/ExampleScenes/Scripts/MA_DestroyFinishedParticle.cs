using UnityEngine;

namespace DarkTonic.MasterAudio.Examples
{
    public class MA_DestroyFinishedParticle : MonoBehaviour
    {
        private ParticleSystem particles;

        // Update is called once per frame
        private void Awake()
        {
            this.useGUILayout = false;
            this.particles = this.GetComponent<ParticleSystem>();
        }

        private void Update()
        {
            if (!this.particles.IsAlive())
            {
                Destroy(this.gameObject);
            }
        }
    }
}