using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lizzard : MonoBehaviour
{
    //references
    Attacker lizzardAttacker;

    // Start is called before the first frame update
    void Start()
    {
        lizzardAttacker = GetComponent<Attacker>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject otherGameObject = collision.gameObject;
        if (otherGameObject.GetComponent<Defender>() != null)
        {
            lizzardAttacker.Attack(otherGameObject);
        }
    }
}
