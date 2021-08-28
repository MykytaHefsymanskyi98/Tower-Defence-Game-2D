using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    //conf param
    [SerializeField] float health = 100f;
    [SerializeField] GameObject destroyedVFX;
    public void GetHit(float damage)
    {
        health = health - damage;
        if(health <= 0)
        {
            PlayDestroyedVFX();
            Destroy(gameObject);                    
        }
    }

    public void PlayDestroyedVFX()
    {
        if(destroyedVFX == null)
        {
            return;
        }
        else
        {
            GameObject enemyDestruction = Instantiate(destroyedVFX, transform.position, Quaternion.identity) as GameObject;
            Destroy(enemyDestruction, 1f);
        }

    }
}
