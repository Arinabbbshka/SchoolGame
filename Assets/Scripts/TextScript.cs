using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextScript : MonoBehaviour
{
    public TextMeshProUGUI text;
    int livess;
    private void Awake()
    {
        Cursor.lockState = CursorLockMode.None;
        livess = PlayerPrefs.GetInt("Itog");
    }
    private void Update()
    {
        if (livess == 2)
        {
            text.text = "�������, �� ������� ��� ����!";
        }
        else
        {
            text.text = "�� ������ ������� ��� ��������������.. ������� ��������� �����!";
        }
    }
}
