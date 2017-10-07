using System.Collections;
using System.Collections.Generic;
using UnityEngine;

  public class CircleBehavior : MonoBehaviour {

   private Rigidbody2D rb2;
   public float charge;

   void Start() {
        rb2 = GetComponent<Rigidbody2D>();
    }

    public void SetForce(Vector2 force)
    {
        rb2.AddForce(force);
    }
}

