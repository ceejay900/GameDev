using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScoreText : MonoBehaviour
{
    public GameObject startPos;
    public TextMeshProUGUI scoreText;
    public GameObject scoreTextObj;
    public TextMeshProUGUI highScore;


    public static float distance;
    // Start is called before the first frame update
    void Start()
    {
        scoreText = scoreTextObj.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        distance = (startPos.transform.position.y + 3.18f + this.transform.position.y);
        scoreText.text = distance.ToString("F1") + "M";

        if(distance > float.Parse(distance.ToString("F1")))
        {
            highScore.text = "Recored: " + distance.ToString("F1");
            Debug.Log(distance.ToString("F1"));
        }

        if(distance >= 40f)
        {
            Debug.Log("asldkfjweoriu");
            
        }
    }
}