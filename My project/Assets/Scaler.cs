using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scaler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Character c = GetComponentInParent<Character>();
        transform.localScale = new Vector3(c.autoAttackRange, 0, c.autoAttackRange);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
