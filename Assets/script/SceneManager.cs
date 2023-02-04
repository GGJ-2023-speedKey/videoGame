using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum EnumScenes
{
    MAIN_MENU,
    GAME,
    CREDITS,
}

public class SceneManager : MonoBehaviour
{

    public EnumScenes scene;

    public void changeScene()
    {
        switch (scene)
        {
            case EnumScenes.GAME:
                UnityEngine.SceneManagement.SceneManager.LoadScene("InGame");
                break;

            case EnumScenes.MAIN_MENU:
                UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
                break;

            case EnumScenes.CREDITS:
                UnityEngine.SceneManagement.SceneManager.LoadScene("Credits");
                break;

        }
    }


}
