using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SetPlayerDestination : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform marker;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    RaycastHit hit;

    private void OnMouseDown()
    {
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit)){
            marker.position = hit.point;
            agent.SetDestination(hit.point);
        }
        //Vector3 screenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
        //screenPoint.z = 10.0f; //distance of the plane from the camera
        
    }

}
