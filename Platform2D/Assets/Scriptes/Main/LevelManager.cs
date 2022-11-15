using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI ScoreNubberText;
   

    private void Start()
    {
        ScoreNubberText = GameObject.Find("ScoreNubber").GetComponent<TextMeshProUGUI>();
    }
    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); 
       
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void quit()
    {
        Application.Quit();
        Debug.Log("quit");
    }

    public void AddScore(int score)
    {
        int ScoreNubber = int.Parse(ScoreNubberText.text);
        ScoreNubber += score;
        ScoreNubberText.text = ScoreNubber.ToString();
    }
}
