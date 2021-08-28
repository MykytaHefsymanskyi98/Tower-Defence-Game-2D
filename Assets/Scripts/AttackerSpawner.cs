using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{


    //conf param
    [SerializeField] Attacker[] attacker;
    [SerializeField] float minTimeSpawn = 0f;
    [SerializeField] float maxTimeSpawn = 5f;

    //states
    bool spawn = true;
    float timeBetweenSpawn;
    float enemyIndex;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        while (spawn == true)
        {
            yield return new WaitForSeconds(Random.Range(minTimeSpawn, maxTimeSpawn));
            Spawn();
            
        }
    }

    public void NotSpawn()
    {
        spawn = false;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    private void SpawnAttacker(Attacker myAttacker)
    {
        Attacker newAttacker = Instantiate(myAttacker, transform.position, Quaternion.identity) as Attacker;
        newAttacker.transform.parent = transform;
    }
    
    private void Spawn()
    {
        int newAttackerSpawning = Random.Range(0, attacker.Length);
        SpawnAttacker(attacker[newAttackerSpawning]);
    }

    
}
