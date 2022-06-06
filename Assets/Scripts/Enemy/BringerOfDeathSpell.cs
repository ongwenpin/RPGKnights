using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BringerOfDeathSpell : Damage
{ 
    [SerializeField] private float projectileResetTime;
    [SerializeField] private float enemyDamage;
    private float projectileLifetime;
    private GameObject player;
    private bool hit = false;

    private void Awake()
    {
        
    }

    public void ActivateProjectile()
    {
        
        projectileLifetime = 0;
        gameObject.SetActive(true);

    }
    private void Update()
    {
        projectileLifetime += Time.deltaTime;
        if (projectileLifetime > projectileResetTime)
            Deactivate();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            hit = true;
            player = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            hit = false;
        }
    }
    private void Deactivate()
    {
        gameObject.SetActive(false);
    }

    IEnumerator Impact()
    {
        if (hit)
        {
            if (damageType == Dmg.magic)
            {
                player.GetComponent<Health>().TakeMagicDamage(enemyDamage);
            }
            else if (damageType == Dmg.physical)
            {
                player.gameObject.GetComponent<Health>().TakePhysicalDamage(enemyDamage);
            } else
            {
                player.gameObject.GetComponent<Health>().TakeTrueDamage(enemyDamage);
            }
        }
        yield return new WaitForSeconds(2f);
        Deactivate();
    }
}

