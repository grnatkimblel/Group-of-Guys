using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class OpponentTesting : MonoBehaviour
{

    NavMeshAgent agent;
    Character character;
    // Start is called before the first frame update
    void Start()
    {
        character = GetComponent<Character>();
        agent = GetComponent<NavMeshAgent>();
        agent.speed = character.movementSpeed;
        agent.SetDestination(new Vector3(0,0,30));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
