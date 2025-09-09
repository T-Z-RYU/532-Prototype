using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform playerCameraPoint;

    private void LateUpdate()
    {
        transform.position = playerCameraPoint.position;
        transform.rotation = playerCameraPoint.rotation;
    }
}
