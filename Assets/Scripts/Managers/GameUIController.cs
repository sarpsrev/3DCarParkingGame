using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUIController : MonoBehaviour
{
    public GameObject imagePrefab;
    public Transform parentTransform;

    private List<Image> imageList = new List<Image>();
    // Start is called before the first frame update
    void Start()
    {
        InstantiateImages(GameManager.Instance.carCount);
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



        void SetTextureToThirdImage(Texture2D texture)
    {
        if (imageList.Count >= 3) // Liste en az 3 elemana sahipse
        {
           // imageList[2].sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
            // 3. elemana texture atandı
        }
    }

    
}
