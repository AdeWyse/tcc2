using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


 public class ScenesController : MonoBehaviour
{
    public void ChangeScene(string scene)
    {
        Cursor.visible = true;
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
