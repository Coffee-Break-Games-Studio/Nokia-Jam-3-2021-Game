using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class Loader
{
    public enum Scene
    {
        GamePlayScene, GameOverScene, ContinueScene, IntroScene, VictolyScene
    }

    public static void Load(Scene scene)
    {
        SceneManager.LoadSceneAsync(scene.ToString());
    }

    public static string currentScene()
    {
        return SceneManager.GetActiveScene().name;
    }
}
