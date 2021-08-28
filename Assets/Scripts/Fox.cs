using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fox : MonoBehaviour
{
    //references
    Attacker foxAttacker;

    // Start is called before the first frame update
    void Start()
    {
        foxAttacker = GetComponent<Attacker>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        GameObject otherGameObject = collision.gameObject;
        if(otherGameObject.tag == "Scarecrow")
        {

            GetComponent<Animator>().SetTrigger("foxJump");
        }
        else if (otherGameObject.GetComponent<Defender>() != null)
        {
            foxAttacker.Attack(otherGameObject);
        }
        
    
    }
}
