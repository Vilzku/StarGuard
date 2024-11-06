using UnityEngine;

public class CameraController : MonoBehaviour
{
    internal static object main;
    [SerializeField] private Transform player;
    [SerializeField] private float smoothTime;
    [SerializeField] private float maxOffsetX;
    [SerializeField] private float maxOffsetY;
    private float heightOffset;
    private Vector3 velocity = Vector3.zero;
    private bool playerHasCameraControl = false;

    void Awake()
    {
        heightOffset = transform.position.z - player.position.z;
    }

    void LateUpdate()
    {
        if (playerHasCameraControl && player)
        {
            ApplySmoothMovement(player.position);
        }
    }

    public void SetPlayerHasCameraControl(bool isEnabled)
    {
        playerHasCameraControl = isEnabled;
    }

    public void ApplySmoothMovement(Vector3 targetPosition)
    {
        Vector3 offsetTargetPosition = new(targetPosition.x, targetPosition.y, targetPosition.z + heightOffset);
        Vector3 smoothPosition = Vector3.SmoothDamp(transform.position, offsetTargetPosition, ref velocity, smoothTime);
        transform.position = new Vector3(
            Mathf.Clamp(smoothPosition.x, -maxOffsetX, maxOffsetX),
            Mathf.Clamp(smoothPosition.y, -maxOffsetY, maxOffsetY),
            transform.position.z
        );
    }
}