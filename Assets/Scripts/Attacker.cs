using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    //references
    GameObject defenderTarget;

    //states
    float movingSpeed;
    float movingSpeedDelta = 0.25f;

    void Awake()
    {
        FindObjectOfType<Level>().AddFoes();
    }
        
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * movingSpeed * Time.deltaTime);
        if (!defenderTarget)
        {
            GetComponent<Animator>().SetBool("isAttacking", false);
        }
    }

    public void SetMovingSpeed(float speed)
    {
        movingSpeed = speed + movingSpeedDelta * PlayerPrefsController.GetDifficulty();
    }

    public void SetRunningSpeed(float runningSpeed)
    {
        movingSpeed = runningSpeed + movingSpeedDelta * PlayerPrefsController.GetDifficulty();
    }

    public void SetAttackMovingSpeed(float speed)
    {
        movingSpeed = speed;
    }

    public void Attack(GameObject target)
    {
        GetComponent<Animator>().SetBool("isAttacking", true);
        defenderTarget = target;       
    }

    private void TriggerEnter2D(Collision2D collision)
    {
        Attack(defenderTarget);
    }

    public void Strike(int damage)
    {
        
        Health defenderHealth = defenderTarget.GetComponent<Health>();
        if(defenderHealth)
        {
            defenderHealth.GetHit(damage);
        }               
    }

    void OnDestroy()
    {
        Level level = FindObjectOfType<Level>();
        if(level != null)
        {
            level.DestroyFoes();
        }
        else
        {
            return;
        }
    }
}
