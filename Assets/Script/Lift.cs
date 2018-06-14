using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Lift : MonoBehaviour {
    public Vector3[] stops;
    public bool playOnAwake = false;
    public float speed;

    public int targetIndex = 0;
    private bool isActive;
    private Vector3 moveVec;
    private Rigidbody rb;

	void Start () {
        rb = GetComponent<Rigidbody>();
        transform.position = stops[targetIndex];
        isActive = playOnAwake;
	}
	void FixedUpdate () {
        if (isActive){
            moveVec = getNewVector();
            float distLeft = Vector3.Distance(transform.position, stops[targetIndex]);
            Vector3 nextMove = moveVec * speed * Time.deltaTime;
            if(nextMove.magnitude >= distLeft) {
                nextMove = nextMove.normalized * distLeft;
                targetIndex++;
                targetIndex = targetIndex % stops.Length;
            }
            //Debug.DrawLine(transform.position, transform.position + nextMove, Color.green);
            rb.MovePosition(transform.position + nextMove);
        }
	}
    Vector3 getNewVector(){
        //Debug.Log("Gettting  " + targetIndex);
        return (stops[targetIndex] - transform.position).normalized;
    }
}
