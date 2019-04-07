using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class AsciiLevelLoader : MonoBehaviour
{
    public string textFile = "/Text/Level1.txt";
    public string Player;
    public string Food;
    
    // Start is called before the first frame update
    void Start()
    {
        string filepath = Application.dataPath + textFile;

        if (!File.Exists(filepath))
        {
            File.WriteAllText(filepath, "X");
        }

        string[] inputLines = File.ReadAllLines(filepath);

        for (int y = 0; y < inputLines.Length; y++)
        {
            string line = inputLines[y];

            for (int x = 0; x < line.Length; x++)
            {
                GameObject tile;

                switch (line[x])
                {
                    case 'X':
                        tile = Instantiate(Resources.Load<GameObject>("Prefabs/Wall"));
                        break;
                    case 'L':
                        tile = Instantiate(Resources.Load<GameObject>("Prefabs/Ledge"));
                        break;
                    case 'M':
                        tile = Instantiate(Resources.Load<GameObject>("Prefabs/MovingLedge"));
                        break;
                    case 'O':
                        tile = Instantiate(Resources.Load<GameObject>("Prefabs/" + Food));
                        break;
                    case 'P':
                        tile = Instantiate(Resources.Load<GameObject>("Prefabs/" + Player));
                        break;
                    default:
                        tile = null;
                        break;
                }

                if (tile != null)
                {
                    tile.transform.position = new Vector2(x - line.Length/2f + 0.5f, inputLines.Length/2f - y);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
