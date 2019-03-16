using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {
    //config params
    [SerializeField] float ScreenWunits = 16f;
    [SerializeField] float minX = 1f;
    [SerializeField] float maxX = 15f;

    //cached refs
    GameStatus thisGame;
    Ball thisBall;

	// Use this for initialization
	void Start () {
        thisGame = FindObjectOfType<GameStatus>();
        thisBall = FindObjectOfType<Ball>();
	}
	
	// Update is called once per frame
	void Update () {
        
        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
        paddlePos.x = Mathf.Clamp(GetXPos(), minX, maxX);
        transform.position = paddlePos;
	}

    private float GetXPos()
    {
        if (thisGame.IsAutoPlayEnabled())
        {
            return thisBall.transform.position.x;
        }
        else
        {
            return (Input.mousePosition.x / Screen.width * 16f);
        }
    }
}
