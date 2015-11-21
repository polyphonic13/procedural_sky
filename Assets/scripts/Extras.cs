using UnityEngine;
using System.Collections;

public class Extras : MonoBehaviour {
	public Renderer lightWall;
	public Renderer water;

	public Transform worldProbe;

	private Material sky;
	private bool lightOn = false; 

	// Use this for initialization
	void Start () {
		sky = RenderSettings.skybox;
	}
	
	// Update is called once per frame
	void Update () {
//		stars.transform.rotation = transform.rotation;

//		if (Input.GetKeyDown (KeyCode.T)) {
//			lightOn = !lightOn;
//		}

//		if (lightOn) {
//			Color final = Color.white * Mathf.LinearToGammaSpace(5);
//			lightWall.material.SetColor(lightWall, final);
//			DynamicGI.SetEmissive(lightWall, final);
//		} else {
//			Color final = Color.white * Mathf.LinearToGammaSpace(0);
//			lightWall.material.SetColor(lightWall, final);
//			DynamicGI.SetEmissive(lightWall, final);
//		}

//		Vector3 tvec = Camera.main.transform.position;
//		worldProbe.transform.position = tvec;

//		water.material.mainTextureOffset = new Vector2(Time.time / 100, 0);
//		water.material.SetTextureOffset("_DetailAbedoMap", new Vector2(0, Time.time / 80));
	}
}
