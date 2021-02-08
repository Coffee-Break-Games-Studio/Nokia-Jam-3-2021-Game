using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public string LayerMaskForShot;
    Collider2D col;
    int layerMaskInt;
    bool shootingDisabled = false;

    void TryShot()
    {
      if (shootingDisabled) return;

      // will only hit 2DColliders in the specified layer mask
      Collider2D hit = Physics2D.OverlapPoint(transform.position, layerMaskInt);
      if (hit != null) {
        shootingDisabled = true; // prevent spamming the game manager
        Debug.Log("Hit: " + hit.gameObject.name);
        // TODO call game manager
      } else {
        // miss
      }
    }
    // Start is called before the first frame update
    void Start()
    {
        col = gameObject.GetComponent<Collider2D>();
        layerMaskInt = LayerMask.NameToLayer(LayerMaskForShot);
    }

    void FixedUpdate()
    {
        if (Input.GetButton("Action")) {
          TryShot();
        }
    }
}
