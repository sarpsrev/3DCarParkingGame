using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Car Settings")]
    public GameObject[] Cars;
    public int carCount;
    int carIndex=0;

    [Header("Platform Settings")]
    public GameObject platform_1;
    public GameObject platform_2;
    public float[] rotationSpeeds;
    public GameObject stopPoint;


    private void Awake() 
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        Cars[carIndex].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.G))
        {
            
            if (carIndex<carCount)
            {
                
                Cars[carIndex].GetComponent<CarControl>().canCarMove = true;

            }
            carIndex++;
            
            
        }
        platform_1.transform.Rotate(new Vector3(0,0,rotationSpeeds[0]),Space.Self);
    }
    public void SetNewCar()
    {
        if (carIndex<carCount)
        {
           Cars[carIndex].SetActive(true);

        }
        stopPoint.SetActive(true);
       
    }

}
