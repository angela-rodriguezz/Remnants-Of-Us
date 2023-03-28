using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScript : MonoBehaviour
{
    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }
}
