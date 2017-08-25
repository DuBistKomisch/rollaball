﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
  public float speed;

  private Rigidbody rb;

  void Start() {
    this.rb = this.GetComponent<Rigidbody>();
  }

  void FixedUpdate() {
    float moveHorizontal = Input.GetAxis("Horizontal");
    float moveVertical = Input.GetAxis("Vertical");

    Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

    this.rb.AddForce(movement * this.speed);
  }

  void OnTriggerEnter(Collider other) {
    if (other.gameObject.CompareTag("Pick Up")) {
      other.gameObject.SetActive(false);
    }
  }
}
