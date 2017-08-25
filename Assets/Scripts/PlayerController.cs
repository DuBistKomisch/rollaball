using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
  public float speed;

  public Text countText;
  public Text winText;

  private Rigidbody rb;

  private int count;
  private int Count {
    get {
      return this.count;
    }
    set {
      this.count = value;
      this.UpdateCount();
    }
  }

  void Start() {
    this.rb = this.GetComponent<Rigidbody>();
    this.Count = 0;
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
      this.Count++;
    }
  }

  private void UpdateCount() {
    this.countText.text = "Count: " + this.Count.ToString();
    this.winText.text = this.Count >= 6 ? "You Win!" : "";
  }
}
