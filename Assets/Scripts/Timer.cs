using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject timerBar;
    public float maxTime = 5f;
    float timeLeft;


    void Start()
    {
        timeLeft = maxTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            timerBar.transform.localScale = new Vector3(1, timeLeft / maxTime, 1);
        }
        else
        {
            Loader.Load(Loader.Scene.GameOverScene);
        }
    }
}
