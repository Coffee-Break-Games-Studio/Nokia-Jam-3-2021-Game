using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject[] respawns;
    private List<int> list = new List<int>();
    private int hits = 0;
    private bool success = false;

    public GameObject character01;
    public GameObject character02;
    public GameObject character03;
    public GameObject character04;
    public GameObject character05;
    public GameObject character06;
    public GameObject character07;
    public GameObject character08;
    public GameObject character09;

    private CursorMovement cursor;

    private void Awake()
    {
        cursor = GameObject.FindObjectOfType<CursorMovement>();
    }

    // Start is called before the first frame update
    void Start()
    {

        if (respawns.Length == 0)
            respawns = GameObject.FindGameObjectsWithTag("Respawn");

        foreach (GameObject respawn in respawns)
        {
            success = false;

            if (hits <= 9)
            {
                while (!success)
                {
                    // give us a random number
                    int random = Random.Range(1, 10); // 1 - 9

                    // is above number not inside of list?
                    if (!list.Contains(random))
                    {
                        // Load a Sprite (Assets/Resources/Sprites/sprite01.png)
                        // var sprite = Resources.Load<Sprite>("Sprites/sprite01");

                        switch (random)
                        {
                            case 1:
                                Instantiate(character01, respawn.transform.position, respawn.transform.rotation);
                                break;
                            case 2:
                                Instantiate(character02, respawn.transform.position, respawn.transform.rotation);
                                break;
                            case 3:
                                Instantiate(character03, respawn.transform.position, respawn.transform.rotation);
                                break;
                            case 4:
                                Instantiate(character04, respawn.transform.position, respawn.transform.rotation);
                                break;
                            case 5:
                                Instantiate(character05, respawn.transform.position, respawn.transform.rotation);
                                break;
                            case 6:
                                Instantiate(character06, respawn.transform.position, respawn.transform.rotation);
                                break;
                            case 7:
                                Instantiate(character07, respawn.transform.position, respawn.transform.rotation);
                                break;
                            case 8:
                                Instantiate(character08, respawn.transform.position, respawn.transform.rotation);
                                break;
                            case 9:
                                Instantiate(character09, respawn.transform.position, respawn.transform.rotation);
                                break;
                            default:
                                Debug.Log("krispen wah");
                                break;
                        }

                        list.Add(random);
                        hits += 1;
                        success = true;
                    }
                }

            }

           
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (cursor.wasHit())
        {
            Debug.Log("GameManager a hit was detected.");
            Debug.Log("Tag = " + cursor.getOther().tag);
            cursor.setHit(false);
        }
    }
}



//// give us a random number
//int random = Random.Range(1, 10); // 1 - 9

//// is above number not inside of list?
//if (!list.Contains(random))
//{
//    // Load a Sprite (Assets/Resources/Sprites/sprite01.png)
//    // var sprite = Resources.Load<Sprite>("Sprites/sprite01");

//    switch (random)
//    {
//        case 1:
//            Instantiate(capsule01, respawn.transform.position, respawn.transform.rotation);
//            break;
//        case 2:
//            Instantiate(capsule02, respawn.transform.position, respawn.transform.rotation);
//            break;
//        case 3:
//            Instantiate(capsule03, respawn.transform.position, respawn.transform.rotation);
//            break;
//        case 4:
//            Instantiate(capsule04, respawn.transform.position, respawn.transform.rotation);
//            break;
//        case 5:
//            Instantiate(capsule05, respawn.transform.position, respawn.transform.rotation);
//            break;
//        case 6:
//            Instantiate(capsule06, respawn.transform.position, respawn.transform.rotation);
//            break;
//        case 7:
//            Instantiate(capsule07, respawn.transform.position, respawn.transform.rotation);
//            break;
//        case 8:
//            Instantiate(capsule08, respawn.transform.position, respawn.transform.rotation);
//            break;
//        case 9:
//            Instantiate(capsule09, respawn.transform.position, respawn.transform.rotation);
//            break;
//        default:
//            Debug.Log("krispen wah");
//            break;
//    }

//    list.Add(random);
//    success += 1;
//}