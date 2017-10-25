using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCam : MonoBehaviour {

    GameObject player;

	// Use this for initialization
	void Start () {

        player = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update (){

        this.transform.position = new Vector3(player.transform.position.x, this.transform.position.y, player.transform.position.z);
        this.transform.rotation = Quaternion.Euler(this.transform.eulerAngles.x, player.transform.eulerAngles.y, this.transform.eulerAngles.z);
		
	}
}
