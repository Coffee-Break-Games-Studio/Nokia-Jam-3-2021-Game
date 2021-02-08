using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public string LayerMaskForShot;
    public float ShootCooldown = 0.5f;
    Collider2D col;
    int layerMaskInt;
    bool shootingDisabled = false;
    float lastShotTime = 0;

    void TryShot()
    {
      if (shootingDisabled || (Time.time - lastShotTime) < ShootCooldown) return;
      lastShotTime = Time.time;

      // will only hit 2DColliders in the specified layer mask
      Collider2D hit = Physics2D.OverlapPoint(transform.position, 1 << layerMaskInt);
      if (hit != null) {
        shootingDisabled = true; // prevent spamming the game manager
        Debug.Log("Hit: " + hit.gameObject.name);
        // TODO call game manager
      } else {
        // miss
        // TODO play sound
        // Debug.Log("Miss");
      }
    }
    // Start is called before the first frame update
    void Start()
    {
        col = gameObject.GetComponent<Collider2D>();
        layerMaskInt = LayerMask.NameToLayer(LayerMaskForShot);
    }

    void Update()
    {
        if (Input.GetButton("Action")) {
          TryShot();
        }
    }
}
