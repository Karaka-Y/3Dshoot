using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour {

	public float speed = 10.0f; //speed of fireball
	public int damage =1; //damage that the player character will have given when collide with fireball 
	// Use this for initialization
	void Start () { //we no need to initializate any properties of this object becouse we have manager, that spawns fireballs
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(0, 0, speed * Time.deltaTime); //moving transform and it also mean moving whole game objest by Z axis by speed units. Also we use Time.deltaTime for moving the object by speed units per one second.
	}

	void OnTriggerEnter(Collider other){ //we have taken a collider of other game object we have tought. One of collider properties is gameObject that has this collider. So when we have a collider, we can use the gameObject methods, like we will do in next lines
		PlayerCharacter player = other.GetComponent<PlayerCharacter>(); //there most of time we will get a null, we check if a collider is relate to player object
		if (player != null){ //if we get component PlayerCharacter - the object is player, rly
			player.Hurt(damage); //we call player method "Hurt" and give to this method variable damage
		}
		Destroy (this.gameObject);// after working with objects that fireball collide we have to destroy it and free memory. Note: if we use only "this" we destroy component Fireball.cs instead of this, we need to destroy gameObject
	}
}
