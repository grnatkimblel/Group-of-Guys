using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AutoAttacker : MonoBehaviour
{

    NavMeshAgent playerAgent;
    Character character;

    public float maxDistance = 1000; // set to players auto attack range
    bool hasMovingTarget = false;

    // Start is called before the first frame update
    void Start()
    {
        character = GetComponent<Character>();
        playerAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        handleMouseInputs();
        if(hasMovingTarget)
        {
            playerAgent.SetDestination(hitOpponent.transform.position); //need this every frame for if the target moves
            if(playerAgent.stoppingDistance == 0f) 
                playerAgent.stoppingDistance = character.autoAttackRange;
        } else
        {
            playerAgent.SetDestination(hitWalkable.point);
            playerAgent.stoppingDistance = 0f;
        }
    }


    RaycastHit hitOpponent;
    bool isMouseOverOpponentGameObject()
    {
        bool val = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitOpponent, maxDistance, LayerMask.GetMask("Opponent"));
        //Debug.Log("isMouseOverCurrentGameObject: " + val);
        return val;
    }

    RaycastHit hitWalkable;
    bool isMouseOverWalkableSurface()
    {
        bool val = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitWalkable, maxDistance, LayerMask.GetMask("Walkable"));
        //Debug.Log("isMouseOverCurrentGameObject: " + val);
        return val;
    }

    void handleMouseInputs()
    {
        if (Input.GetMouseButtonDown(1) || Input.GetMouseButton(1)) //if user has right click down
        {

            if (isMouseOverOpponentGameObject()) //if user Right clicks on an opponent
            {
                hasMovingTarget = true;
            }
            else
            {
                if (isMouseOverWalkableSurface())
                {
                    hasMovingTarget = false;
                }
            }
            
        }
        if (Input.GetMouseButtonUp(1)) //if user lets go of right click on this frame
        {

        }
    }

}
