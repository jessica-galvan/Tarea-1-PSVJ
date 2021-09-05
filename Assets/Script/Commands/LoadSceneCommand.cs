using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadSceneCommand : ICommand
{
    string scene;

    public LoadSceneCommand(string scene)
    {
        this.scene = scene;
        GameManager.instance.AddEvent(this);
    }

    public void Do()
    {
        SceneManager.LoadScene(scene);
    }
}
