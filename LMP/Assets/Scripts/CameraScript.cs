using UnityEngine;
public class CameraScript : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float cameraSpeed = 0.3f;
    private Vector3 velocity;
    private void Start()
    {
        velocity = GetComponent<Transform>().position;
    }
    void FixedUpdate()
    {
        transform.position = Vector3.SmoothDamp(transform.position, new Vector3(player.position.x, 1, -10), ref velocity, cameraSpeed);
    }
}