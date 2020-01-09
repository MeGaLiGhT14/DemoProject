using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void OnPlayButtonClick(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void OnAuthorsButtonClick(Animator animator)
    {
        animator.SetBool("IsOpen" , !animator.GetBool("IsOpen"));
    }

    public void OnExitButtonClick()
    {
        Application.Quit();
    }
}