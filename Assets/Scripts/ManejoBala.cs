using UnityEngine;

public class ManejoBala : MonoBehaviour
{
    public LayerMask capaDestruccion;
    
    void OnCollisionEnter(Collision collision)
    {
        if (capaDestruccion.value == (capaDestruccion.value | (1 << collision.gameObject.layer)))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
            FindAnyObjectByType<Disparo>()?.VerificarVictoria();
        }
    }
}
