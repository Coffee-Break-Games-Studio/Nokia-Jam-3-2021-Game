using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundWindowCovers : MonoBehaviour
{

    public GameObject[] covers;
    public void ToggleCovers()
    {
        for (int i = 0; i < covers.Length; i++) {
          covers[i].SetActive(!covers[i].activeSelf);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // randomly open or close them
        for (int i = 0; i < covers.Length; i++) {
          covers[i].SetActive(Random.Range(0,1) == 1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
