using UnityEngine;

public class EnemyProjectile : EnemyDamage
{

    [SerializeField] private float projectileSpeed;
    [SerializeField] private float projectileResetTime;
    private float projectileLifetime;

    private bool hit;
    private Animator anima;
    private BoxCollider2D boxCollider;

    private void Awake()
    {
        anima = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    public void ActivateProjectile()
    {
        hit = false;
        projectileLifetime = 0;
        gameObject.SetActive(true);

    }
    private void Update()
    {
        if (hit) return;

        float movementSpeed = projectileSpeed * Time.deltaTime;
        transform.Translate(movementSpeed * transform.localScale.x, 0, 0);

        projectileLifetime += Time.deltaTime;
        if (projectileLifetime > projectileResetTime)
            gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {

            hit = true;
            base.OnTriggerEnter2D(collision);
            boxCollider.enabled = false;


            if (anima != null)
                anima.SetTrigger("explode");
            else
                gameObject.SetActive(false);
        }
    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
    }
   
}
