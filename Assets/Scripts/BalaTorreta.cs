using UnityEngine;

public class BalaTorreta : MonoBehaviour
{
    public float speed = 20f;
    public int damage = 3;
    public float lifetime = 3f;

    private Turret turret; // Referencia a la torreta que disparó

    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    public void SetTurret(Turret t)
    {
        turret = t;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemigo"))
        {
            IDamageable damageable = other.GetComponent<IDamageable>();
            if (damageable != null)
            {
                damageable.TakeDamage(damage);
                turret?.ContarMuerte(); // Registrar muerte en la torreta
            }

            Destroy(gameObject);
        }
    }
}
