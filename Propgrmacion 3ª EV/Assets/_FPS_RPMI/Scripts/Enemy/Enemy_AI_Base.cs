using UnityEngine;
using UnityEngine.AI; //Libreria de componentes NavMesh

public class Enemy_AI_Base : MonoBehaviour
{
    #region Genereal Variables
    [Header("AI Configuration")]
    [SerializeField] NavMeshAgent agent; // Ref al cerebro del agente
    [SerializeField] Transform target; //Ref al target a perseguir (variable)
    [SerializeField] LayerMask targetLayer; //Define el layer del target (Detecciones)
    [SerializeField] LayerMask groundLayer; //Define el layer del suelo (Evita ir a zonas sin suelo)

    [Header("Patrolling Stats")]
    [SerializeField] float walkPointsRange = 10f; //Radio maximo para determinar puntos a perseguir
    Vector3 walkPoint; //Posicion del punto random a perseguir
    bool walkPointSet; //¿Hay punto a perseguir generado? Si es false, genera uno


    [Header("Attacking stats")]
    [SerializeField] float timeBetweenAttacks = 1f; //Cooldown entre ataques
    [SerializeField] GameObject projectile; //Ref a la bala fisica que dispara el enemigo
    [SerializeField] Transform shootPoint; //Posicion desde la que se dispara la bala
    [SerializeField] float shootSpeedY; //Fuerza de disparo hacia arriba (Catapulta)
    [SerializeField] float shootSpeedZ = 10f; //Fuerza de disparo hacia delante (Siempre está)
    bool alreadyAttacked; //Si es verdadero no stackea ataques y netra en espera entre ataques

    [Header("States & Detection")]
    [SerializeField] float sightRange = 8f; //radio del detector de persecución
    [SerializeField] float attackRange = 2f; //radio del detector de ataque
    [SerializeField] bool targetInSightRange; //Determina si es verdadero que podemos perseguir al target
    [SerializeField] bool targetInAtackRange; //Determina si es verdadero que podemos atacar al target

    [Header("Stuck Detection")]
    [SerializeField] float stuckCheckTime = 2f; //Tiempo que el agente espera estando quieto antres de darse cuenta de que esta stuck
    [SerializeField] float stuckThreshold = 0.1f; //Margen de detecion de stuck
    [SerializeField] float maxStuckThreshold = 3f; //Tiempo maximo de estar stuck

    float stuckTimer; //Reloj que cuenta el tiempo de estar stuck
    float lastCheckTime; //Tiempo de chequeo previo de stuck
    Vector3 lastPosition; //Posicion del ultimo walkpoint perseguido
    #endregion

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
