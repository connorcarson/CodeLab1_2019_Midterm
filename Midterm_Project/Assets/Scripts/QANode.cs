using System.Collections;
using System.Collections.Generic;

public class QANode
{   
    public string questionText;
    public string option1Text;
    public string option2Text;

    public int pageNumber;
    public int option1Page;
    public int option2Page;
    public int option3Page;

    public QANode option1;
    public QANode option2;

    public QANode() //default
    {
        pageNumber = 0;
        questionText = "This is the default question text.";
        option1Text = "Yes";
        option2Text = "No";
    }

    public QANode(int pageNumber, string questionText)
    {
        this.pageNumber = pageNumber;
        this.questionText = questionText;
    }

    public QANode(int pageNumber, string questionText, string option1Text, string option2Text)
    {
        this.pageNumber = pageNumber;
        this.questionText = questionText;
        this.option1Text = option1Text;
        this.option2Text = option2Text;
    }
}
