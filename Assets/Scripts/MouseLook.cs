using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour {
	public enum RotationAxes{ //перечисление выглядит в инспекторе как выпадающий список, в котором можно выбирать необходимый параметр
		MouseXAndY = 0,
		MouseX = 1,
		MouseY = 2
	}
	public RotationAxes axes = RotationAxes.MouseXAndY;

	public float sensitivityHor = 9f;
	public float sensitivityVert = 9.0f;
	public float minimumVert = -45.0f;
	public float maximumVert = 45.0f;

	private float _rotationX = 0;
	// Use this for initialization
	void Start () {
		Rigidbody body = GetComponent<Rigidbody>();
		if(body != null){
			body.freezeRotation = true;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (axes == RotationAxes.MouseX){
			transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityHor, 0);
			// rotation in horizontal ploscost'
		}
		else if (axes == RotationAxes.MouseY){
			_rotationX = _rotationX - Input.GetAxis("Mouse Y") * sensitivityVert;
			_rotationX = Mathf.Clamp(_rotationX, minimumVert, maximumVert);
			float _rotationY = transform.localEulerAngles.y;

			transform.localEulerAngles = new Vector3(_rotationX, _rotationY, 0);
			// rotation in vertical ploscost'
		}
		else {
			_rotationX = _rotationX - Input.GetAxis("Mouse Y") * sensitivityVert;
			_rotationX = Mathf.Clamp(_rotationX, minimumVert, maximumVert);
			float delta = Input.GetAxis("Mouse X") * sensitivityHor;
			float rotationY = transform.localEulerAngles.y + delta;

			transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
			// combined rotation
		}
	}
}
