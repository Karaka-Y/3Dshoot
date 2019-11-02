using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSInput : MonoBehaviour {
	public float moveSpeed = 6.0f;
	public float gravity = -9.8f;

	private CharacterController _charController; //i use character controller that no need to be shown in the inspector
	// Use this for initialization
	void Start () {
		_charController = GetComponent<CharacterController>(); //i get character controller, attached to gameObject
	}
	
	// Update is called once per frame
	void Update () {
		float deltaX = Input.GetAxis("Horizontal") * moveSpeed; //-1..1 * moving speed, it represent a direction of player move
		float deltaZ = Input.GetAxis("Vertical") * moveSpeed; // the same thing to vertical, that mean moving forward/backward in the game

		Vector3 movement = new Vector3(deltaX, 0, deltaZ); // vector that represents character moving direction
		movement = Vector3.ClampMagnitude(movement, moveSpeed); //i use clampMagnitude for alignment moving speed when moving diagonaly
		movement.y = gravity; //-9.8 units by y per frame
		movement = movement * Time.deltaTime; //alignment moving with frame rates
		movement = transform.TransformDirection(movement); // transform direction from local space to world space, becouse we need to mowe object rely to the camera instead of object coordinates

		_charController.Move(movement); //use this method to move controller and the whole gameObject. Moving is constrained by collisions
	}
}
