
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Play()
    {
        //Load Scene
        //SceneManager.LoadScene("SceneName"); <-- alternative to using the scene index
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //Scene index control, Level 1 is #1 in cue
    }
    public void Quit()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }
    public void CustomGame()
    {
        Debug.Log("Here you can customize your experience");

        //Add variables here that will be public / serialized that can be 
        //tuned by the player on the main menu, ie; Bomb count down timer, Bomb bump timer reset
        //Frog speed, Fly spawn-rate, Adding more bombs on the field.
    }
}

