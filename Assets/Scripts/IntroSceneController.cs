using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class IntroSceneController : MonoBehaviour
{
    public GameObject XButton;
    public GameObject EventSystemObj; 
    EventSystem eventSystem;
    Animator animator;

    public void OnPlaySelected()
    {
        eventSystem.sendNavigationEvents = false;
        animator.SetTrigger("PlayGame");
    }

    public void OnQuitSelected()
    {
        Debug.Log("Quit selected");
    }

    public void OnAnimCameraDownEvent()
    {
      // Debug.Log("Camera moved down");
    }
    public void OnAnimBountyAppearEvent()
    {
      // Debug.Log("Bounty appeared");
      XButton.SetActive(true);
    }

    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        eventSystem = EventSystemObj.GetComponent<EventSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
