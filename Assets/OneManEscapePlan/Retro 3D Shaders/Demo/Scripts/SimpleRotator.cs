using UnityEngine;

public class SimpleRotator : MonoBehaviour
{

    public Vector3 speed;

    // Update is called once per frame
    private void Update()
    {
        transform.Rotate(speed * Time.deltaTime);
    }
}
