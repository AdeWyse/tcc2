using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


static public class ScenesController 
{
    public static  void ChangeScene(string scene)
    {
        Cursor.visible = true;
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
    }

    public static void Exit()
    {
        Application.Quit();
    }
}
