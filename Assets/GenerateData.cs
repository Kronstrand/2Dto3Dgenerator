using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GenerateData : MonoBehaviour {


    int i = 0;
    float timer = 0;
    String filePathTarget = "C:/Users/kronstrand/Documents/Data/target/target_";
	string filePathInput = "C:/Users/kronstrand/Documents/Data/input/input_";

    Camera playerCam;
    Camera mapCam;


    // Use this for initialization
    void Start () {

        playerCam = GameObject.Find("Player/MainCamera").GetComponent<Camera>();
        mapCam = GameObject.Find("MapCamHolder/MapCam").GetComponent<Camera>();
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        timer += Time.deltaTime;
    }

    void LateUpdate()
    {
        if (timer > 0.2f)
        {
            StartCoroutine(saveScreen());
            i++;
            timer = 0;
        }
    }

    public IEnumerator saveScreen()
    {
        yield return new WaitForEndOfFrame();

        //take a screenshot and store as a texture
        Texture2D tex = new Texture2D(playerCam.pixelWidth, playerCam.pixelHeight);
        tex.ReadPixels(new Rect(playerCam.pixelRect.x, playerCam.pixelRect.y, playerCam.pixelWidth, playerCam.pixelHeight), 0, 0);
        tex.Apply();

        //save the screenshot as jpg
        File.WriteAllBytes(filePathTarget + i + ".jpg", tex.EncodeToJPG());


        //take a screenshot and store as a texture
        tex = new Texture2D(mapCam.pixelWidth, mapCam.pixelHeight);
        tex.ReadPixels(new Rect(mapCam.pixelRect.x, mapCam.pixelRect.y, mapCam.pixelWidth, mapCam.pixelHeight), 0, 0);
        tex.Apply();

        //save the screenshot as jpg
        File.WriteAllBytes(filePathInput + i + ".jpg", tex.EncodeToJPG());
        
    }
}
