using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CoinController : MonoBehaviour
{
    
    [SerializeField] TextMeshProUGUI ScoreNubberText;
    [SerializeField] float CoinSpeed;
    

    private void Update()
    {
        transform.Rotate(new Vector3(0f, CoinSpeed, 0f));
        
    }
   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {


            //int ScoreNubber = int.Parse(ScoreNubberText.text);
            //ScoreNubber += 50;
            //ScoreNubberText.text = ScoreNubber.ToString();
            GameObject.Find("LevelManager").GetComponent<LevelManager>().AddScore(50);
            Destroy(gameObject);

        }
    }

}
