using UnityEngine;

public class AutoDestruirBala : MonoBehaviour
{
    public float tiempoVida = 5f;
    
    void Start()
    {
        Destroy(gameObject, tiempoVida);
    }

}
