using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using System.Xml;
using UnityEngine.SceneManagement;

public class QAManager : MonoBehaviour
{
    public QANode currentNode;

    public Text questionText;
    public Text option1Text;
    public Text option2Text;

    private string fileLocation;
    
    // Start is called before the first frame update
    void Start()
    {
        string fileLocation = Application.dataPath + "/Text/QAPage1.json"; //create path to .json file
        
        //WriteNewJson(fileLocation); //write file for the first time
        
        ReadFromJson(fileLocation);
        
        UpdateUI(currentNode);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void WriteNewJson(string fileLocation)
    {
        currentNode = new QANode(
            1,
            "You come to a fork in the road.\n There is also a spoon here.",
            "Take fork",
            "Take Spoon");

        string JsonStr = JsonUtility.ToJson(currentNode, true);
        print(JsonStr);
        
        File.WriteAllText(fileLocation, JsonStr);
    }

    public void ChooseOption(int pageNumber) //option function for button UI
    {
        switch (currentNode.pageNumber)
        {
            case 1:
                fileLocation = Application.dataPath + "/Text/QAPage" + currentNode.option1Page + ".json";
                if (pageNumber != 1)
                {
                    fileLocation = Application.dataPath + "/Text/QAPage" + currentNode.option2Page + ".json";
                }

                break;
            case 2:
                if (pageNumber == 1)
                {
                    SceneManager.LoadScene(1);
                }
                else
                {
                    fileLocation = Application.dataPath + "/Text/QAPage1.json";
                }

                break;
            case 3:
                if (pageNumber == 1)
                {
                    print("No Scene to load.");
                }
                else
                {
                    fileLocation = Application.dataPath + "/Text/QAPage1.json";
                }

                break;
            default:
                break;
        }
        // print(currentNode.pageNumber);
        
        //convert that .json file into text
        ReadFromJson(fileLocation);
        //update the UI according to that text
        UpdateUI(currentNode);
    }

    void ReadFromJson(string fileLocation) //convert .Json text into text in current node
    {
        string Input = File.ReadAllText(fileLocation);
        print(Input);

        currentNode = JsonUtility.FromJson<QANode>(Input);
    }

    void UpdateUI(QANode node) //update UI text according to our current QA node
    {
        questionText.text = node.questionText;
        option1Text.text = node.option1Text;
        option2Text.text = node.option2Text;
    }
}
