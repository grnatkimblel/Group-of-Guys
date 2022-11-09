using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AutoAttacker : MonoBehaviour
{

    NavMeshAgent playerAgent;
    Character character;

    public float maxDistance = 1000; // set to players auto attack range
    bool targetingAttackableEntity = false;

    // Start is called before the first frame update
    void Start()
    {
        character = GetComponent<Character>();
        playerAgent = GetComponent<NavMeshAgent>();
        playerAgent.speed = character.movementSpeed;
        Debug.Log(hitWalkable);
    }

    private void OnDrawGizmosSelected()
    {
        
        Gizmos.DrawWireSphere(transform.position , playerAgent.remainingDistance);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        handleMouseInputs();
        if(targetingAttackableEntity)
        {
            playerAgent.SetDestination(hitOpponent.transform.position); //need this every frame for if the target moves
           
            if (playerAgent.remainingDistance < character.autoAttackRange)
            {
                Debug.Log("AutoAttacking");
                playerAgent.SetDestination(playerAgent.transform.position);
                StartCoroutine(AutoAttack());
                
            }
            else playerAgent.SetDestination(hitOpponent.transform.position);

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
            Debug.Log("user has right clicked");
            if (isMouseOverOpponentGameObject()) //if user Right clicks on an opponent
            {
                targetingAttackableEntity = true;
            }
            else
            {
                if (isMouseOverWalkableSurface())
                {
                    targetingAttackableEntity = false;
                    playerAgent.SetDestination(hitWalkable.point);
                    playerAgent.stoppingDistance = 0f;
                }
            }
            
        }
        if (Input.GetMouseButtonUp(1)) //if user lets go of right click on this frame
        {

        }
    }

    float determineStoppingDistance() //determines how far from the opponent the user should stop to successfully autoattack.
    {
  

        GameObject opponent = hitOpponent.transform.gameObject;
        float opponentMovementSpeed = opponent.GetComponent<Character>().movementSpeed;
        return character.autoAttackRange - character.autoAttackStartUpTime * opponentMovementSpeed;
    }

   

    IEnumerator AutoAttack()
    {
        GameObject opponent = hitOpponent.transform.gameObject;
        yield return new WaitForSeconds(character.autoAttackStartUpTime);
        opponent.GetComponent<Character>().dealDamage(10);
    }

}
