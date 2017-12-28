using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

	public void PlayGame()
    {
        SceneManager.LoadScene("Labyrinth 1.0 Desktop");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
