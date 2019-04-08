using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Image winPanel;
    public Button playAgainButton;
    public GameObject winText;
    public Text foodLeft;
    public string foodNum;


    public int foods;
    public int Food
    {
        get
        {
            return foods;
        }
        set
        {
            foods = value;
            foodLeft.text = foods + foodNum;
        }
    }

    public static GameManager instance;
    
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            //DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        GameOver();
    }

    private void GameOver()
    {
        if (Food <= 0)
        {
            winText.SetActive(true);
            playAgainButton.gameObject.SetActive(true);
            winPanel.gameObject.SetActive(true);
        }
    }

    public void StartOver()
    {
        SceneManager.LoadScene(0);
    }
}
