using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarControl : MonoBehaviour
{
    public Transform parent;
    public bool canCarMove;
    public GameObject[] trailRenderer;
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
            GameManager.Instance.SetNewCar();

            for (int i = 0; i < trailRenderer.Length; i++)
            {
                trailRenderer[i].SetActive(false);
            }
        }
        if (other.gameObject.CompareTag("PlatformMid")||other.gameObject.CompareTag("Car"))
        {
            Destroy(gameObject);
            
        }        
    }
}
