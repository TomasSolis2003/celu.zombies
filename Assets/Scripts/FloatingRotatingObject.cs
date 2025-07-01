using UnityEngine;

public class FloatingRotatingObject : MonoBehaviour
{
    [Header("Rotaci�n")]
    public float rotationSpeed = 90f; // Grados por segundo

    [Header("Movimiento Vertical")]
    public float floatAmplitude = 0.25f; // Qu� tan alto/bajo se mueve
    public float floatSpeed = 2f;        // Qu� tan r�pido se mueve

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        // Rotar sobre el eje Y
        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);

        // Movimiento vertical tipo seno
        float newY = startPos.y + Mathf.Sin(Time.time * floatSpeed) * floatAmplitude;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}
