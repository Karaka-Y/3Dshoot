using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderingAI : MonoBehaviour {

	public float mSpeed = 3.0f;
	public float obstacleRange = 5.0f;

	[SerializeField] private GameObject fireballPrefab;
	[SerializeField] private GameObject fireParticlePrefab;
	private GameObject _fireball;
	private GameObject _fireParticle;
	private bool _alive;
	// Use this for initialization
	void Start () {
		_alive = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (_alive){
		transform.Translate(0, 0, mSpeed * Time.deltaTime);
		}

		Ray ray = new Ray(transform.position, transform.forward);
		RaycastHit hit;
		if(Physics.SphereCast(ray, 0.75f, out hit)){
			GameObject hitObject = hit.transform.gameObject;
			if (hitObject.GetComponent<PlayerCharacter>()){
				if (_fireball == null){
					_fireball = Instantiate(fireballPrefab) as GameObject;
					_fireball.transform.position = transform.TransformPoint(Vector3.forward * 1.5f);
					_fireball.transform.rotation = transform.rotation;
					_fireParticle = Instantiate(fireParticlePrefab) as GameObject;
					_fireParticle.transform.parent = _fireball.transform;
					_fireParticle.transform.position = _fireball.transform.position;
					_fireParticle.transform.rotation = _fireball.transform.rotation;
					_fireParticle.transform.Rotate(180, 0, 0);
					//_fireParticle.transform.position = new Vector3(0,0,0);
				}
			}
		else if (hit.distance < obstacleRange){
				float angle = Random.Range(-110, 110);
				transform.Rotate(0, angle, 0);
			}

		}
	}

	public void SetAlive (bool alive){
		_alive = alive;
	}
}
