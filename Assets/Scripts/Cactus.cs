using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cactus : MonoBehaviour
{
    //conf param
    [SerializeField] GameObject cactusBullet;
    [SerializeField] GameObject gun;
    [SerializeField] float health = 100;

    //states
    const string PROJECTILE_PARENT_NAME = "Projectiles";

    //references
    AttackerSpawner myLaneSpawner;
    Animator animator;
    GameObject projectilesParent;

    // Start is called before the first frame update
    void Start()
    {
        SetLaneSpawner();
        animator = GetComponent<Animator>();
        CreateProjectileParent();
    }
    private void CreateProjectileParent()
    {
        projectilesParent = GameObject.Find(PROJECTILE_PARENT_NAME);
        if(!projectilesParent)
        {
            projectilesParent = new GameObject(PROJECTILE_PARENT_NAME);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(IsAttackerInLane())
        {
            animator.SetBool("isAttacking", true);
        }
        else
        {
            animator.SetBool("isAttacking", false);
        }
    }
    public void Attack()
    {     
            GameObject newProjectile = Instantiate(cactusBullet, gun.transform.position, transform.rotation) as GameObject;
            newProjectile.transform.parent = projectilesParent.transform;
    }
    private bool IsAttackerInLane()
    {
        if (myLaneSpawner != null)
        {
            if (myLaneSpawner.transform.childCount <= 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        else
        {
            return false;
        }
    }
    private void SetLaneSpawner()
    {
        AttackerSpawner[] spawners = FindObjectsOfType<AttackerSpawner>(); 
       foreach(AttackerSpawner spawner in spawners)
        {
            bool positionCheck = (Mathf.Abs(spawner.transform.position.y - transform.position.y) <= Mathf.Epsilon);
            if(positionCheck)
            {
                myLaneSpawner = spawner;
            }
        }
    }


}
