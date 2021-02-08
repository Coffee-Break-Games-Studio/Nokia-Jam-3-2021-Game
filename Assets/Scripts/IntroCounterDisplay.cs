using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroCounterDisplay : MonoBehaviour
{
    [Tooltip("Sprite to use as 'points' in counter box")]
    public Sprite PointSprite;
    [Tooltip("GameObject which will be parent to all points and start position")]
    public GameObject InitialPositionObject;
    int score;
    // Start is called before the first frame update
    void Start()
    {
        // TODO get score from game manager
        score = 5; // TODO replace with value from game manager

        if (score > 5) score = 5; // limit of 5 (visual limitation)
        for (int i = 0; i < score; i++) {
            GameObject point = new GameObject("Point" + i);
            float offset = (PointSprite.rect.width * i);
            if (i > 0) offset += 1 * i; // spacing

            SpriteRenderer ren = point.AddComponent<SpriteRenderer>();
            ren.sprite = PointSprite;
            //ren.size = new Vector2(PointSprite.rect.width, PointSprite.rect.height);

            point.transform.SetParent(InitialPositionObject.transform, false);
            point.transform.localPosition = new Vector3(offset, 0, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
