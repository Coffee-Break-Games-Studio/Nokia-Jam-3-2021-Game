using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverController : MonoBehaviour
{
    public AudioClip EndSong;
    AudioController audioController;

    // Start is called before the first frame update
    void Start()
    {
        audioController = GameObject.FindGameObjectWithTag("AudioController").GetComponent<AudioController>();
        audioController.Play(EndSong);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Action")) {
          IntroSceneController.IntroSceneVisisted = false;
          Loader.Load(Loader.Scene.IntroScene);
        }
    }
}
