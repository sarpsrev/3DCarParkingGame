using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarControl : MonoBehaviour
{
    public Transform parent;
    public bool canCarMove;
    public GameObject[] trailRenderer;

    bool canStop;
    
    [Header("Other Scripts")]
    public GameUIController gameUIController;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!canStop)
        {
            transform.Translate(5f * Time.deltaTime * transform.forward);
        }
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

            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        }
        if (other.gameObject.CompareTag("PlatformMid"))
        {
            Destroy(gameObject);
            GameManager.Instance.GameCondition = "LOSE";
            gameUIController.GameConditionController();
        }
        if (other.gameObject.CompareTag("StopPoint"))
        {
            canStop = true;
            GameManager.Instance.stopPoint.SetActive(false);
        }
        if(other.gameObject.CompareTag("Diamond"))
        {
            Debug.Log("here");
            GameManager.Instance.diamondCount++;
            Destroy(other.gameObject);
        }        
    }
}
