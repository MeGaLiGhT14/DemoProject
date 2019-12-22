using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void OnKlickPlay(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void OnKlickAuthors(Animator animator)
    {
        animator.SetBool("IsOpen" , !animator.GetBool("IsOpen"));
    }

    public void OnKlickExit()
    {
        Application.Quit();
    }
}