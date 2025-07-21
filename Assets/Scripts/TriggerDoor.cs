using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerDoor : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        PlayerPrefs.SetInt("Itog", InventoryManager.thingsCount);
        SceneManager.LoadScene(4);
        
    }
}
