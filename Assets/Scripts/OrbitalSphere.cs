using UnityEngine;

public class OrbitalSphere : MonoBehaviour
{
    public Transform target;         // El jugador
    public float orbitRadius = 2f;
    public float orbitSpeed = 50f;
    public int damage = 2;
    private float angle;

    void Update()
    {
        if (target == null) return;

        angle += orbitSpeed * Time.deltaTime;
        float rad = angle * Mathf.Deg2Rad;
        Vector3 offset = new Vector3(Mathf.Cos(rad), 0, Mathf.Sin(rad)) * orbitRadius;
        transform.position = target.position + offset;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemigo"))
        {
            IDamageable damageable = other.GetComponent<IDamageable>();
            if (damageable != null)
            {
                damageable.TakeDamage(damage);
            }
        }
    }
}
