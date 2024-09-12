using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IUGame : MonoBehaviour
{
    public void OnMainMenuButtonClick(string mainMenu)
    {
        SceneManager.LoadScene(mainMenu);
    }
}