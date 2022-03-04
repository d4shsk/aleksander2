using UnityEngine;


public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Vector3 adding;

    void Update()
    {
        transform.position = player.position + adding;
    }
}
