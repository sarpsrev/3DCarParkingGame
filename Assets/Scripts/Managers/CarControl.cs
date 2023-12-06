using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarControl : MonoBehaviour
{
    public Transform parent;
    public bool canCarMove;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(canCarMove)
        {
            transform.Translate(10f * Time.deltaTime * transform.forward);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Parked"))
        {
            canCarMove=false;
            transform.SetParent(parent);
        }
        if (other.gameObject.CompareTag("PlatformMid"))
        {
            Destroy(gameObject);
            
        }        
    }
}
