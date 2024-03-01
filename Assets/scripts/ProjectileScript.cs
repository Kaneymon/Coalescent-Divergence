using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    //this script handles the despawning of projectiles
    [SerializeField]
    float DeathTime;

    [SerializeField]
    ParticleSystem deathParticles;

    private float projectileDamage;

    private void Awake()
    {
        projectileDamage = GameObject.Find("PlayerGun").GetComponent<GunScript>().GetBulletDamage();
    }

    void deathTimer()
    {
        DeathTime -= Time.deltaTime;
        if (DeathTime <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void Update()
    {
        deathTimer();
    }

    private void OnDestroy()
    {
        deathParticles.Play();
        //might have to instantiate it with its own death box ticked instead.
    }

    //to damage enemies
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Enemy"))
        {
            EnemyController collisionEnemy = collision.transform.GetComponent<EnemyController>();
            collisionEnemy.SetEnemiesHealth(collisionEnemy.GetEnemiesHealth() - projectileDamage);
        }
    }

}
