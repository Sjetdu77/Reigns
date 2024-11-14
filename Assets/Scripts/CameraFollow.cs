using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    public Vector3 positionOffset;

    private Vector3 velocity = Vector3.zero;

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + positionOffset;
    }
}
