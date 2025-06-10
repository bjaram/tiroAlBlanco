using UnityEngine;

public class Obstaculo : MonoBehaviour
{
    public float desplazamientoX = 20f;
    public float duracion = 3f;
    private Vector3 posicionInicial;
    private float tiempo;

    void Start()
    {
        posicionInicial = transform.position;
    }

    void Update()
    {
        tiempo += Time.deltaTime;
        float t = Mathf.PingPong(tiempo / duracion, 1f);
        float easeT = Mathf.SmoothStep(0f, 1f, t);

        float nuevoX = Mathf.Lerp(posicionInicial.x, posicionInicial.x + desplazamientoX, easeT);
        transform.position = new Vector3(nuevoX, posicionInicial.y, posicionInicial.z);
    }
}
