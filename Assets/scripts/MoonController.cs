using UnityEngine;
using System.Collections;

public class MoonController : MonoBehaviour {

	public float maxIntensity = 0f;
	public float minIntensity = 0.5f;
	public float minPoint = -0.2f; 

	public Vector3 dayRotationSpeed = new Vector3(-2, 0, 0);
	public Vector3 nightRotationSpeed = new Vector3(-2, 0, 0); 
	
	private float skySpeed = 1f;
	
	private Light mainLight;
	// Use this for initialization
	void Start () {
		mainLight = GetComponent<Light> ();
	}
	
	// Update is called once per frame
	void Update () {
		float tRange = 1 - minPoint;
		float dot = Mathf.Clamp01 ((Vector3.Dot (mainLight.transform.forward, Vector3.down) - minPoint) / tRange);
		float i = ((maxIntensity - minIntensity) * dot) + minIntensity;
		
		mainLight.intensity = i;
		

		if(dot > 0) {
			this.transform.Rotate(dayRotationSpeed * Time.deltaTime * skySpeed);
		} else {
			this.transform.Rotate(nightRotationSpeed * Time.deltaTime * skySpeed);
		}

	}
}
