using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Mainmanager : MonoBehaviour
{
    [SerializeField]  GameObject username;
    [SerializeField] float CoinSpeed;
    [SerializeField] Image CoinImage;
    [SerializeField] GameObject game;
    
 

    
    void Update()
    {
        CoinImage.rectTransform.Rotate(new Vector3(0f, CoinSpeed, 0f));
         game.transform.Rotate(new Vector3(0f, CoinSpeed, 0f));
       
    }
}
