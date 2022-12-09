using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public void RestartGame()
    {
        gameObject.GetComponent<AudioSource>().Play();
        Invoke("SceneRestart", 0.2f);
    }
    private void SceneRestart()
    {
        gameObject.SetActive(false);
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);

    }
}
