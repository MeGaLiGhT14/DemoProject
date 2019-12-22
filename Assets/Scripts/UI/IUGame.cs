using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IUGame : MonoBehaviour
{
    public void OnClickMainMenu(string mainMenu)
    {
        SceneManager.LoadScene(mainMenu);
    }
}