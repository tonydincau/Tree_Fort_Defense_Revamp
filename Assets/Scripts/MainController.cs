using UnityEngine;
using System.Collections;

public class MainController : MonoBehaviour {
	
	//CAMERAS//
	public Camera mainCamera;
	
	//GAMEOBJECTS//
	public GameObject ammoSpawner;
	private GameObject selectedObject;
	
	//SCRIPTS//
	public CameraScroll cameraScrollScript;
	public Projectile projectileScript;
	public UserInput UserInputRef;
	
	//INTS//
	//FLOATS//
	//BOOLS//
	//VECTORS//
	private Vector3 ammoVector;
	
	//RAYS//
	private Ray shootRay;
	private RaycastHit hitRay;
	
	
	void Awake(){
		cameraScrollScript = mainCamera.GetComponent<CameraScroll>() as CameraScroll;
		UserInputRef = gameObject.GetComponent<UserInput>() as UserInput;
	}
	
	void FixedUpdate(){
		
		if(Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began){
			shootTheRay();
		}
		
		if(selectedObject != null){
			if(selectedObject.tag=="Projectile" && Input.touches[0].phase == TouchPhase.Ended){
				projectileScript.Shoot();
				selectedObject = null;
			}
		}
		
	}
	
	public GameObject shootTheRay(){
		
		shootRay = Camera.main.ScreenPointToRay(Input.touches[0].position);
		
		if (Physics.Raycast (shootRay, out hitRay, 50f)) {
			
			if(hitRay.collider.gameObject.name == "TouchBackground"){
				cameraScrollScript.enabled = true;
			}
			else if(hitRay.collider.gameObject.tag == "Projectile"){
				selectedObject = hitRay.collider.gameObject;
				projectileScript = selectedObject.GetComponent<Projectile>() as Projectile;
				projectileScript.enabled = true;
			}
			else if(hitRay.collider.gameObject.tag == "UI"){
				
			}
			else{
			}
			
			return hitRay.collider.gameObject;
		}
		
		else{
			return null;
		}
	}
	
	private void DisableEverything(){
		if(cameraScrollScript.enabled){
		cameraScrollScript.enabled = false;}
		if(selectedObject.tag == "Projectile" && projectileScript.enabled){
		projectileScript.enabled = false;}
	}
}
