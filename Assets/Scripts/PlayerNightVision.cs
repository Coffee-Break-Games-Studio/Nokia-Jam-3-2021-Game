using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNightVision : MonoBehaviour
{
    public float ToggleCooldownSeconds = 2.0f; // cooldown in seconds
    public GameObject inverter;
    [Tooltip("GameObject with window covers (Most likely in the background prefab)")]
    public BackgroundWindowCovers WindowCovers;
    public AudioClip ToggleOnAudio;
    public AudioClip ToggleOffAudio;
    AudioController audioController;

    float lastUseTime = 0;

    void toggleNightVision()
    {
        inverter.SetActive(!inverter.activeSelf);
        WindowCovers.ToggleCovers();

        if (inverter.activeSelf) audioController.Play(ToggleOnAudio);
        else audioController.Play(ToggleOffAudio);
    }
    // Start is called before the first frame update
    void Start()
    {
        audioController = GameObject.FindGameObjectWithTag("AudioController").GetComponent<AudioController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("NightVision")) {
          if (Time.time - lastUseTime < ToggleCooldownSeconds) {
            return;
          }
          lastUseTime = Time.time;
          toggleNightVision();
        }
    }
}
