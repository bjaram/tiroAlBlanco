using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Disparo : MonoBehaviour
{
    
    [System.Serializable]
    public class CuboData
    {
        public Vector3 posicionInicial;
        public GameObject prefab;
        public float duracion;
    }

    [Header("Configuracion Customizada")] 
    public GameObject balaPrefab;
    public Transform puntoDeDisparo;
    public float velocidadBala = 100f;
    public int maxBalas = 10;
    public float tiempoVida = 3f;
    public TMP_Text cajaMensaje;
    
    [Header("Configuracion para obstaculos")]
    public LayerMask capaCubes;
    public List<CuboData> cubosOriginales;
    
    
    private Camera _camaraPrincipal;
    private int _balasDisparadas;
    private bool _habilitarReinicio = false;
    private List<GameObject> _cubosInstanciados = new List<GameObject>();
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _camaraPrincipal = Camera.main;
        _balasDisparadas = 0;
        InstanciarCubos();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Disparar();
        }
        
        if (_habilitarReinicio && Input.GetKeyDown(KeyCode.R))
        {
            Reiniciar();  
        }
    }

    void Disparar()
    {
        if (_balasDisparadas < maxBalas)
        {
            Vector3 direccionBala = ObtenerDireccionDisparo();
            DispararBalaConDireccion(direccionBala);
            _balasDisparadas++;
        }
        else
        {
            cajaMensaje.text = "Presiona R para reiniciar el juego.";
            _habilitarReinicio = true;
        }
    }

    Vector3 ObtenerDireccionDisparo()
    {
        Vector2 posicionMouse = Mouse.current.position.ReadValue();
        Ray rayo = _camaraPrincipal.ScreenPointToRay(new Vector3(posicionMouse.x, posicionMouse.y, 0));
        
        RaycastHit hit;
        Vector3 puntoObjetivo;
            
        if (Physics.Raycast(rayo, out hit, Mathf.Infinity))
        {
            puntoObjetivo = hit.point;
        }
        else
        {
            puntoObjetivo = rayo.GetPoint(100f);
        }
        
        return (puntoObjetivo - puntoDeDisparo.position).normalized;
    }

    void DispararBalaConDireccion(Vector3 direccion)
    {
        GameObject bala = Instantiate(
            balaPrefab,
            puntoDeDisparo.position,
            Quaternion.LookRotation(direccion)
        );

        Rigidbody rb = bala.GetComponent<Rigidbody>();
        rb.linearVelocity = direccion * velocidadBala;
        
        ManejoBala balaScript = bala.AddComponent<ManejoBala>();
        balaScript.capaDestruccion = capaCubes;
        
        AutoDestruirBala autoDestruir = bala.AddComponent<AutoDestruirBala>();
        autoDestruir.tiempoVida = tiempoVida;
    }

    public void Reiniciar()
    {
        foreach (GameObject cubo in _cubosInstanciados)
        {
            if (cubo != null)
                Destroy(cubo);
        }

        _cubosInstanciados.Clear();
        InstanciarCubos();

        _balasDisparadas = 0;
        cajaMensaje.text = "";
    }
    
    private void InstanciarCubos()
    {
        foreach (CuboData cubo in cubosOriginales)
        {
            GameObject nuevoCubo = Instantiate(cubo.prefab, cubo.posicionInicial, Quaternion.identity);
            Obstaculo obstaculos = nuevoCubo.AddComponent<Obstaculo>();
            obstaculos.duracion = cubo.duracion;
            _cubosInstanciados.Add(nuevoCubo);
        }
    }
    
    public void VerificarVictoria()
    {
        GameObject[] cubos = GameObject.FindGameObjectsWithTag("Cubo");
        if (cubos.Length == 1)
        {
            cajaMensaje.text = "¡Ganaste!\nPresiona R para volver a empezar.";
            _habilitarReinicio = true;
        }
    }
}
