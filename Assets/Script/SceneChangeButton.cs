using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeButton : MonoBehaviour
{
    [SerializeField] private string nextScene;

    public void Clicked(){
        SceneManager.LoadScene(nextScene);
    }
}
