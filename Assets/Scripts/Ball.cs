using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    private Paddle paddle;
    private bool hasStarted = false;

    private Vector3 paddleToBallVector;
    private Rigidbody2D rigidbody1;

	// Use this for initialization
	void Start () {
        paddle = GameObject.FindObjectOfType<Paddle>();
        paddleToBallVector = this.transform.position - paddle.transform.position;
        rigidbody1 = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        if (!hasStarted)
        {
            // zakljucava loptu relativno od palice.
            this.transform.position = paddle.transform.position + paddleToBallVector;

            //cekanje na pritisak levog klika misa da bi se lansirala loptica.
            if (Input.GetMouseButtonDown(0))
            {
                hasStarted = true;
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(2f, 10f);
            }
        }
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 tweek = new Vector2 (Random.Range(0f, 0.2f), Random.Range(0f, 0.2f));
        rigidbody1.velocity += tweek;
    }
}
