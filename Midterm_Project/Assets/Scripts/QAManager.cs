using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using System.Xml;

public class QAManager : MonoBehaviour
{
    private QANode currentNode;

    public Text questionText;
    public Text option1Text;
    public Text option2Text;
    
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
    {   //which .json file are we referencing
        string fileLocation = Application.dataPath + "/Text/QAPage" + currentNode.option1Page + ".json";
        if (pageNumber != 1)
        {
            fileLocation = Application.dataPath + "/Text/QAPage" + currentNode.option2Page + ".json";
        }        
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
