using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text cheeriosLeft;
    
    private int foods = 15;
    public int Food
    {
        get
        {
            return foods;
        }
        set
        {
            foods = value;
            cheeriosLeft.text = foods + "/15";
        }
    }

    public static GameManager instance;
    
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
