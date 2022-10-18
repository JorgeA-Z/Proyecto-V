using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Scene_Manager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LoadGame() 
    {
        SceneManager.LoadScene("Game");
        
    }


    public void LoadInstructions() 
    {
        SceneManager.LoadScene("Instruction");

    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("MainMenu");

    }

    public void ExitGame()
    {
        Application.Quit();
    }

}
