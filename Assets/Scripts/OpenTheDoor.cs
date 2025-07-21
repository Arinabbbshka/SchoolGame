using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenTheDoor : MonoBehaviour
{
    static public bool OpenDoor = false;
    public GameObject Door;
    void Update()
    {
    }
    public void OpenDoorEffect()
    {
        Door.SetActive(false);
    }
}
