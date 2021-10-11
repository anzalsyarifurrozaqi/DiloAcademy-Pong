using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour {
    private Rigidbody2D rigidbody2D;

    public float xInitialForce;
    public float yInitialForce;
    
    private Vector2 trajectoryOrigin;
    
    void ResetBall() {
        transform.position = Vector2.zero;

        rigidbody2D.velocity = Vector2.zero;        
    }

    void PushBall() {
        float yRandomInitialForce = yInitialForce;

        float randomDirection = Random.Range(0, 2);

        if (randomDirection < 1.0f) {
            rigidbody2D.AddForce(new Vector2(-xInitialForce, yRandomInitialForce));
        }
        else {
            rigidbody2D.AddForce(new Vector2(xInitialForce, yRandomInitialForce));
        }
    }

    void RestartGame() {
        ResetBall();

        Invoke("PushBall", 2);
    }

    private void Start() {
        rigidbody2D = GetComponent<Rigidbody2D>();
        trajectoryOrigin = transform.position;
        RestartGame();
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        trajectoryOrigin = transform.position;
    }

    public Vector2 TrajectoryOrigin
    {
        get { return trajectoryOrigin; }
    }
}
