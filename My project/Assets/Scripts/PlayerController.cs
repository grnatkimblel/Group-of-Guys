using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{

    public NavMeshAgent agent;
    RaycastHit hitinfo;
    public Transform marker;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    Vector3 playerTransform = new Vector3();

    private void OnMouseDown()
    {
        Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitinfo);
        //Vector3 screenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
        //screenPoint.z = 10.0f; //distance of the plane from the camera
        playerTransform = hitinfo.point;
        marker.position = playerTransform;
        agent.SetDestination(playerTransform);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(playerTransform, 1);
    }

}
