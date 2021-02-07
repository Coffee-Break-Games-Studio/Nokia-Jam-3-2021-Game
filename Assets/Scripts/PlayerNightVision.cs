using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNightVision : MonoBehaviour
{
    public float ToggleCooldownSeconds = 2.0f; // cooldown in seconds
    public GameObject inverter;

    bool onCoolDown = false;
    float lastUseTime = 0;

    void toggleNightVision()
    {
        inverter.SetActive(!inverter.activeSelf);
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("NightVision")) {
          if (onCoolDown && (Time.time - lastUseTime) < ToggleCooldownSeconds) {
            return;
          }
          onCoolDown = true;
          lastUseTime = Time.time;
          toggleNightVision();
        }
    }
}
