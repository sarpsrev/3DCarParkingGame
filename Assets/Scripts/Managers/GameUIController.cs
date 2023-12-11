using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUIController : MonoBehaviour
{
    public GameObject imagePrefab;
    public Transform parentTransform;
    public Texture2D carOKImg;
    public Text carCountText;
    int textCount;
    

    

    private List<Image> imageList = new List<Image>();
    // Start is called before the first frame update
    void Start()
    {
        InstantiateImages(GameManager.Instance.carCount);
        SetTextureToCarCounterImage();
        textCount=GameManager.Instance.carCount;
        carCountText.text = textCount.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InstantiateImages(int count)
    {
    for (int i = 0; i < count; i++)
    {
        GameObject newImageObj = Instantiate(imagePrefab, parentTransform);
        Image newImage = newImageObj.GetComponent<Image>();
        imageList.Add(newImage);
    }
    }


    public void SetTextureToCarCounterImage()
    {

           imageList[GameManager.Instance.carIndex].sprite = Sprite.Create(carOKImg, new Rect(0, 0, carOKImg.width, carOKImg.height), Vector2.zero);

        
    }

    public void setCarCountText()
    {
        textCount--;
        carCountText.text = textCount.ToString(); 

    }

    
}
