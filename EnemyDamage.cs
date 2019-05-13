using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] int hitPoints = 5;
    [SerializeField] ParticleSystem hitParticlePrefab;
    [SerializeField] ParticleSystem deathtParticlePrefab;


    // Update is called once per frame
   private void OnParticleCollision (GameObject other)
    {
        ProccessHit();
        if(hitPoints <= 0)
        {
            KillEnemy();
        }
    }
    void ProccessHit()
    {
        hitPoints = hitPoints - 1;
        hitParticlePrefab.Play();
        //print(" current hitpoints are " + hitPoints);

    }
    private void KillEnemy()
    {
        var vfx = Instantiate(deathtParticlePrefab, transform.position, Quaternion.identity);
        vfx.Play();
        Destroy(vfx.gameObject, vfx.main.duration);

        Destroy(gameObject);
    }
}
