using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public TMP_Text Text;
    private void Start()
    {
        
    }
    void Update()
    {
        for (int i = 0; i < 3; i++)
        {
            Text.text = list[i];

        }
    }
    private void OnMouseDown()
    {
        
    }
    List<string> list = new List<string>()
    { 
        "Какая же на улице погода замечательная...",
        "Ой, мне же домой пора",
        "Надо срочно заканчивать все дела!"
    };


    
}
