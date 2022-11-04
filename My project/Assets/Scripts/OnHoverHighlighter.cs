using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnHoverHighlighter : MonoBehaviour
{
    Material intialMat;
    //Material glowingMaterial;
    RaycastHit hit;
    //int layerMask;
    float maxDistance = 100f;
    //public LayerMask mask;

    // Start is called before the first frame update
    void Start()
    {
        intialMat = GetComponent<Renderer>().material;
        intialMat.color = Color.blue;
        //int layerMask = LayerMask.GetMask("Opponent");
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, maxDistance, LayerMask.GetMask("Opponent")))
        {
            intialMat.color = Color.green;
        }
        else
        {
            intialMat.color = Color.blue;
        }

        
    }


}
