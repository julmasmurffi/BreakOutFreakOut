using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {
    //config params
    [SerializeField] float ScreenWunits = 16f;
    [SerializeField] float minX = 1f;
    [SerializeField] float maxX = 15f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float mousePosX = (Input.mousePosition.x / Screen.width * 16f);
        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);

        paddlePos.x = Mathf.Clamp(mousePosX, minX, maxX);

        transform.position = paddlePos;
	}
}
