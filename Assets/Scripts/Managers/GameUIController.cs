using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameUIController : MonoBehaviour
{
    [Header("GamePlay UI Elements")]
    public GameObject imagePrefab;
    public Transform parentTransform;
    public Texture2D carOKImg;
    public Text carCountText;
    int textCount;

    [Header("GameOver UI Elements")]
    public GameObject endGamePanel;
    public Text allCoinText;
    public Text endGameTxt;
    public Text levelCountText;
    public Text endGameButtonTxt;
    public RawImage endGameImg;
    public Texture2D winTexture;
    public Texture2D loseTexture;
    

    

    private List<Image> imageList = new List<Image>();
    // Start is called before the first frame update
    void Start()
    {
        InstantiateImages(GameManager.Instance.carCount);
        SetTextureToCarCounterImage();
        textCount=GameManager.Instance.carCount;
        carCountText.text = textCount.ToString();
        setPlayerPrefs();
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

    public void setPlayerPrefs()
    {
        allCoinText.text = PlayerPrefs.GetInt("Coin").ToString();
        levelCountText.text = SceneManager.GetActiveScene().name;
    }

    public void GameConditionController()
    {
        if (GameManager.Instance.GameCondition=="LOSE")
        {
            endGamePanel.SetActive(true);
            endGameImg.texture = loseTexture;
            endGameTxt.text = "YOU LOST";
            endGameButtonTxt.text = "TRY AGAIN";
            
        }
        else if(GameManager.Instance.GameCondition=="WIN")
        {
            endGamePanel.SetActive(true);
            endGameImg.texture = winTexture;
            endGameTxt.text = "YOU WIN!";
            endGameButtonTxt.text="NEXT LEVEL";

        }
    }

    
}
