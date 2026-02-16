using UnityEngine;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    //The function that is set to the Quit button to close the game
    public void Exit()
    {
        Application.Quit();
    }
    
    //This function is set to the Start button to go to the game screen
    public void Begin()
    {
        SceneManager.LoadScene("Start");
    }

}
