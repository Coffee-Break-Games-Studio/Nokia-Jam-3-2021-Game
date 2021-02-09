using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverController : MonoBehaviour
{
    public AudioClip ButtonPressAudio;
    AudioController audioController;

    public void OnContinueSelected()
    {
        audioController.Play(ButtonPressAudio);
        Loader.Load(Loader.Scene.IntroScene);
    }

    public void OnQuitSelected()
    {
        audioController.Play(ButtonPressAudio);
        Application.Quit();
    }
    // Start is called before the first frame update
    void Start()
    {
        audioController = GameObject.FindGameObjectWithTag("AudioController").GetComponent<AudioController>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
