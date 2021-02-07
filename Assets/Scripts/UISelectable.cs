using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UISelectable : MonoBehaviour, IPointerDownHandler
{
    public Button button;
    public Sprite notSelectedSprite;
    public Sprite selectedSprite;

    

    public void OnPointerDown(PointerEventData eventData) {

    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
