using UnityEngine;

namespace BrainFailProductions.PolyFew
{
    [ExecuteInEditMode]
    public class RefreshEnforcer : MonoBehaviour
    {
        // Start is called before the first frame update
        private void Start()
        {
            DestroyImmediate(this);
        }

        // Update is called once per frame
        private void Update()
        {

        }
    }
}