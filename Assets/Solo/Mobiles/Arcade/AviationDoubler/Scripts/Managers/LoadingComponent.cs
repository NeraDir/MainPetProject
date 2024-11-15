using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingComponent : MonoBehaviour
{
    public int scene;

    public float time;

    private void Start()
    {
        Invoke("Load", time);
    }

    private void Load() 
    {
        SceneManager.LoadScene(scene);
    }
}
