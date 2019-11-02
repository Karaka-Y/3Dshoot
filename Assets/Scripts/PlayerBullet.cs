using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour {

	public float speed = 40.0f;
	public int timeToDie = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(0, 0, speed * Time.deltaTime);
		timeToDie ++;
		if(timeToDie > 180){
			Destroy(this.gameObject);
			timeToDie = 0;
		}
    }
	void OnTriggerEnter(Collider other){
		ReactiveTarget target = other.GetComponent<ReactiveTarget>();
		if(target != null){
			target.ReactToHit();
		}
			Destroy(this.gameObject);}

}
