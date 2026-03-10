using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    [Header("Health System Configuration")]
    [SerializeField] int health; //Vida actual del enemigo
    [SerializeField] int maxhealth; //Vida maxima del enemigo

    [Header("Feedback Configuration")]
    [SerializeField] Material damageMat; //Ref al material que da feedback de dañado
    [SerializeField] MeshRenderer enemyRend; //Ref al renderer del enemigo
    [SerializeField] GameObject deathVFx; //Ref al sistema de particulas de muerte
    Material baseMat; //Ref al material base del modelo del enemigo

    private void Awake()
    {
        health = maxhealth; //Cuando se genera el enemigfo su vida actual se carga a la maxima
        baseMat = enemyRend.material; //Se almacena el material base del modelo del enemigo
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            health = 0; //La vida no puede bajar de cero
            deathVFx.SetActive(true); //Enecendemos del CFx de muerte
            deathVFx.transform.position = transform.position; //Ponemos el VFx en la posicion actual del enemigo
            gameObject.SetActive(false); //Se apaga el enemigo = "muere"
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage; //Quitar tanta vida como valor de daño viene de fuera
        enemyRend.material = damageMat; //Se cambia el material base por el material dañado
        Invoke(nameof(ResetEnemyMat), 0.1f); //Llamar al resteo del material con 0.1 segundos de espera
    }

    void ResetEnemyMat()
    {
        enemyRend.material = baseMat; //Cambiar el material del modelo al material base
    }
}
