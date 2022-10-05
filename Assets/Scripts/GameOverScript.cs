using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{

    public TextMeshProUGUI pointText;
    public void SetUp(string score)
    {
        gameObject.SetActive(true);
        pointText.text = score.ToString() + " M";
    }
    public void RestartButton(int sceneID)
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene(sceneID);
    }
    public void MainMenuButton()
    {
        Debug.Log("MainMenu");
    }
}