using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeTransparent : MonoBehaviour {
	public LayerMask layer;
	private void OnTriggerEnter(Collider other) {
		if(other.gameObject.layer == layer.value)
			return;
		Debug.Log("Got Entyer");
		Renderer otherR = other.gameObject.GetComponent<Renderer>();
		if(otherR != null){
			Color c;
			foreach(Material m in otherR.materials){
				c = m.color;
				c.a = 0f;
				m.color = c;
			}
		}
	}
	void OnTriggerExit(Collider other){
		if((other.gameObject.layer & layer.value) == 0)
			return;
		Debug.Log("Got Exit");
		Renderer otherR = other.gameObject.GetComponent<Renderer>();
		if(otherR != null){
			Color c;
			foreach(Material m in otherR.materials){
				c = m.color;
				c.a = 254f;
				m.color = c;
			}
		}
	}
}
