using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button StartGame;
    public Button Shops;
    public Button Setting;
    public Button Instruction;
    public Button Exit;

    public string NewInsScene;

    public void GameStart(){
        SceneManager.LoadScene("Main");
    }

    public void Shopping(){

    }

    public void Set() {

    }

    public void Instruct(){
        SceneManager.LoadScene(NewInsScene); 
    }

    public void QuitGame(){
        Debug.Log("Thank you for playing!!");
        Application.Quit();
    }


}
