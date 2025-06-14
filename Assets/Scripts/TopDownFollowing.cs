using UnityEngine;

public class TopDownCameraFollowing : MonoBehaviour
{
    public Transform target;        // El personaje a seguir
    public Vector3 offset = new Vector3(0f, 10f, 0f);  // Posición desde arriba
    public float smoothSpeed = 5f;  // Qué tan suave sigue la cámara

    void LateUpdate()
    {
        if (target == null) return;

        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.position = smoothedPosition;

       
    }
}

