using UnityEngine;
using System.Collections;

public class SkySettings : MonoBehaviour {

	public Transform stars;

	public Gradient nightDayColor;

	public float maxIntensity = 3f;
	public float minIntensity = 0f;
	public float minPoint = -0.2f; 

	public float maxAmbient = 1f;
	public float minAmbient = 0f;
	public float minAmbientPoint = -0.2f;

	public Gradient nightDayFogColor;
	public AnimationCurve fogDensityCurve;
	public float fogScale = 1f;

	public float dayAtmosphereThickness = 0.4f;
	public float nightAtmosphereThickness = 0.87f;

	public Vector3 dayRotationSpeed = new Vector3(-2, 0, 0);
	public Vector3 nightRotationSpeed = new Vector3(-2, 0, 0); 

	private float skySpeed = 1f;

	private Light mainLight;
	private Skybox sky;
	private Material skyMat;

	// Use this for initialization
	void Start () {
		mainLight = GetComponent<Light> ();
		skyMat = RenderSettings.skybox;

	}
	
	// Update is called once per frame
	void Update () {
		float tRange = 1 - minPoint;
		float dot = Mathf.Clamp01 ((Vector3.Dot (mainLight.transform.forward, Vector3.down) - minPoint) / tRange);
		float i = ((maxIntensity - minIntensity) * dot) + minIntensity;

		mainLight.intensity = i;

		tRange = 1 - minAmbientPoint;
		dot = Mathf.Clamp01 ((Vector3.Dot (mainLight.transform.forward, Vector3.down) - minAmbientPoint) / tRange);
		i = ((maxAmbient - minAmbient) * dot) + minAmbient;
		RenderSettings.ambientIntensity = i;

		mainLight.color = nightDayColor.Evaluate (dot);
		RenderSettings.ambientLight = mainLight.color;

		RenderSettings.fogColor = nightDayFogColor.Evaluate (dot);
		RenderSettings.fogDensity = fogDensityCurve.Evaluate (dot) * fogScale;

		i = (((dayAtmosphereThickness - nightAtmosphereThickness) * dot) + nightAtmosphereThickness);
		skyMat.SetFloat("_AtmosphereThickness", i);

		Debug.Log ("dot = " + dot + " rot = " + (dayRotationSpeed * Time.deltaTime * skySpeed));
		if(dot > 0) {
			this.transform.Rotate(dayRotationSpeed * Time.deltaTime * skySpeed);
		} else {
			this.transform.Rotate(nightRotationSpeed * Time.deltaTime * skySpeed);
		}

		stars.rotation = this.transform.rotation;

		if(Input.GetKeyDown(KeyCode.Q)) skySpeed *= 0.5f;
		if(Input.GetKeyDown(KeyCode.E)) skySpeed *= 2f;
	}
}
