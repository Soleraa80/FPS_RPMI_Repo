using UnityEngine;
using UnityEngine.InputSystem;

public class GunSystem : MonoBehaviour
{

    #region General Variables
    [Header("General Referencies")]
    [SerializeField] Camera fpsCam; //Ref si disparamos desde el cento de la camara
    [SerializeField] Transform shootPoint; // Ref si queremos disparar desde la punta del cañón
    [SerializeField] LayerMask impactLayer; //Layer con la que el Raycast interactua
    RaycastHit hit; //Almacén de la información de los objetos a los que el Raycast puede impactar

    [Header("Weapon Parameters")]
    [SerializeField] int damage = 10; //Daño del arma por bala
    [SerializeField] float range = 100f; //Distancia de disparo
    [SerializeField] float spread = 0; //Radio de dispersión del arma
    [SerializeField] float shootingCooldown = 0.2f; //Tiempo entre disparo
    [SerializeField] float reloadTime = 1.5f; //Tiempo de recarga en segundos
    [SerializeField] bool allowButtonHold = false; //Si el disparo se ejecuta por click (falso) o por mantener (true)

    [Header("Bullet Management")]
    [SerializeField] int ammoSize = 30; //Cantidad max de balas por cargador
    [SerializeField] int bulletPerTap = 1; //Cantidad de balas disparadas por disparo
    int bulletsLeft; //Cantidad de balas dentro del cargador actual

    [Header("Feedback References")]
    [SerializeField] GameObject impactEffect; //Ref al VFX de impacto de bala

    [Header("Dev - Gun State Bools")]
    [SerializeField] bool shooting; //Indica si estamos disparando
    [SerializeField] bool canShot; //Indica si podemos disparar en X momento del juego
    [SerializeField] bool reloading; //Indica si estamos en proceso de recarga

    #endregion

    private void Awake()
    {
        bulletsLeft = ammoSize; //Al iniciar la partida tenemos el cargador lleno 
        canShot = true; //Al iniciar la partida tenemos la posibilidad de disparar
    }

    void Update()
    {
        
    }

    void shoot()
    {
        //ESTE ES EL METODO MAS IMPORTANTE
        //AQUI SE DEFINE EL DISPARO POR RAYCAST = UTILIZABLE CON CUALQUIER MECANICA

        //almacenar la direccion de disparo y modificarla en caso de haber spread
        Vector3 direction = fpsCam.transform.forward; //Se lanza rayo hacia delante de la camara
        //Añadir dispersion aleatoria segun dispersion del spread
        direction.x += Random.Range(-spread, spread);
        direction.y += Random.Range(-spread, spread);

        //DECLARACION DEL RAYCAST
        //Physics.Raycast (origen del rayo, direcion, almacen de la info del impacto, layer con la que impacta el rayo)
        if (Physics.Raycast(fpsCam.transform.position, direction, out hit, range, impactLayer))
        {
            //aqui puedo codear todos los efectos para mi interacion
            Debug.Log(hit.collider.name);
        }
    }

    #region Input Methods
    public void OnShoot(InputAction.CallbackContext context)
    {

    }

    public void OnReload(InputAction.CallbackContext context)
    {

    }


    #endregion
}
