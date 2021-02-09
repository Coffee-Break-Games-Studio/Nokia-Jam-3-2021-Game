using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class IntroSceneController : MonoBehaviour
{
    public GameObject XButton;
    public GameObject EventSystemObj; 
    [Tooltip("GameObject which will be the parent of the bounty board")]
    public GameObject BountyHolder;
    [Tooltip("List of possible sprites to choose as targets")]
    public Sprite[] BountySprites;
    public AudioClip ButtonPressAudio;
    EventSystem eventSystem;
    Animator animator;
    bool canContinue = false;
    GameManager gameManager;
    AudioController audioController;
    public static bool IntroSceneVisisted = false;

    public void Awake()
    {
        animator = gameObject.GetComponent<Animator>();
        eventSystem = EventSystemObj.GetComponent<EventSystem>();
        IntroSceneSetState();
        IntroSceneVisisted = true;
    }
    public void OnPlaySelected()
    {
        eventSystem.sendNavigationEvents = false;
        audioController.Play(ButtonPressAudio);
        animator.SetTrigger("PlayGame");
    }

    public void OnQuitSelected()
    {
        audioController.Play(ButtonPressAudio);
        Application.Quit();
    }

    public void OnAnimCameraDownEvent()
    {
      // Debug.Log("Camera moved down");
    }
    public void OnAnimBountyAppearEvent()
    {
      canContinue = true;
      // Debug.Log("Bounty appeared");
    }
    public void OnAnimBountyAppearAndWaitEvent()
    {
      XButton.SetActive(true);
    }

    void CreateRandomBounty()
    {
      int i = Random.Range(1, BountySprites.Length); // maxExclusive
      GameObject bountyPrefabTemplate = Resources.Load<GameObject>("BountyPrefabTemplate");

      // create the bounty board
      GameObject bounty = Instantiate(bountyPrefabTemplate, BountyHolder.transform);

      // for javy... automatic loading
      // Sprite bountySprite = Resources.Load<Sprite>("Bounties/Bounty0" + i); // will break at i > 9!
      Sprite bountySprite = BountySprites[i - 1];

      // ma-ma mia, das a big null exception error
      bounty.transform.Find("Bounty").GetComponent<SpriteRenderer>().sprite = bountySprite;

      Debug.Log("Bounty selected: " + i);
      gameManager.BountySelect(i);

    }

    void IntroSceneSetState()
    {
      if (!IntroSceneVisisted) return;
      // intro scene has been visited, fast forward to bottom of scene
      eventSystem.sendNavigationEvents = false;
      transform.position = new Vector3(0, -84, 0); // hardcoded from animation end state
      animator.SetTrigger("FastForwardBottom");
    }

    // Start is called before the first frame update
    void Start()
    {
        audioController = GameObject.FindGameObjectWithTag("AudioController").GetComponent<AudioController>();
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        CreateRandomBounty();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Action") && canContinue) {
            canContinue = false; // prevent multiple fires
            Debug.Log("Transition");
            audioController.Play(ButtonPressAudio);
            Loader.Load(Loader.Scene.GamePlayScene);
        }
    }
}
