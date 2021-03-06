﻿using System.Collections;
using UnityEngine.UI;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour {
	public float speed;
	public Text countText;
	public Text winText;

	private Rigidbody rb;
	private int count;

	void Start() {
		rb = GetComponent<Rigidbody>();
		count = 0;
		SetCountText();
		winText.text = "";
	}
	void FixedUpdate() {
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");
		Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical);
		movement = Quaternion.Euler(0f,45f,0f) * movement;
		rb.AddForce(movement * speed);
	}
	void OnTriggerEnter(Collider other) {
		if(other.gameObject.CompareTag("Pick Up")) {
			other.gameObject.SetActive(false);
			count += 1;
			SetCountText();
		}
	}
	void SetCountText() {
		countText.text = "Count: " + count.ToString();
		if(count >= 12)
			winText.text = "You Win!";
	}
}
