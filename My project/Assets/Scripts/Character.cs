using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Character : MonoBehaviour
{
    public float autoAttackRange;
    public float autoAttackStartUpTime;
    public int autoAttackDamage;

    public int health;

    public float movementSpeed;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(health <= 0)
        {
            die();
        }
    }

    public void dealDamage(int damage)
    {
        this.health -= damage;
    }

    void die()
    {
        Destroy(gameObject);
    }
}
