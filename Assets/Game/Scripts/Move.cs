﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //if (Input.GetKey(KeyCode.W))
        {
            this.transform.Translate(new Vector3(0, 0, 1) * Time.deltaTime * 10f);
        }
	}
}
