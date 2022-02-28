using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ScriptNavMesh : MonoBehaviour
{

    private GameObject jugador;
    private NavMeshAgent enemigo;
    public Vida saludEnemigo;

    // Start is called before the first frame update
    void Start()
    {
        jugador = GameObject.FindGameObjectWithTag("Player");
        enemigo = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        enemigo.destination = jugador.transform.position;
    }

    public void MatarObjeto()
    {
        //un efecto de partículas
        //una animación
        Destroy(gameObject);
    }
}
