using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {
	
	private float damage = 2.0f;
	private int speed = 30;
	private int slingShotStrength = 14;
	private float maxAmmoDistance = 0.5f;
	private float ammoDistance = 0.0f;
	private GameObject ammoSpawner;
	private Vector3 ammoVector;
	public bool released = false;
	
	
	// Use this for initialization
	void Start () {
		ammoSpawner = gameObject.transform.parent.gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		
		if(!released && Input.touchCount > 0){
			
			transform.Translate(Input.GetTouch(0).deltaPosition/speed);
			gameObject.transform.LookAt(ammoSpawner.transform);
			
		}
		
		ammoDistance = Vector3.Distance(ammoSpawner.transform.position, gameObject.transform.position);
		
		if (ammoDistance > maxAmmoDistance){
        	ammoVector = ammoSpawner.transform.position - gameObject.transform.position;
        	ammoVector = ammoVector.normalized;
       		ammoVector *= (ammoDistance-maxAmmoDistance);
        	gameObject.transform.position += ammoVector;

    	}
	}
	
	public void Shoot(){
		if(!released){
		Debug.Log ("Shoot!");
			released = true;
			gameObject.rigidbody.useGravity=true;
			gameObject.rigidbody.AddForce(gameObject.transform.forward * (ammoDistance*slingShotStrength), ForceMode.VelocityChange);
			//slingBand.SetPosition(1,ammoSpawner.transform.position);
			//Debug.Log("Shooting ammunition in direction "+cursorLocation.transform.forward+" with a speed of "+ammoDistance*slingShotStrength);
			//yield WaitForSeconds(.1);
			//createAmmo();
		}
	}
}