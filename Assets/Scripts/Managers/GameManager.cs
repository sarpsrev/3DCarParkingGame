using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject Car;

    [Header("Platform Settings")]
    public GameObject platform_1;
    public GameObject platform_2;
    public float[] rotationSpeeds;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.G))
        {
            Car.GetComponent<CarControl>().canCarMove = true;
        }
        platform_1.transform.Rotate(new Vector3(0,0,rotationSpeeds[0]),Space.Self);
    }

}
