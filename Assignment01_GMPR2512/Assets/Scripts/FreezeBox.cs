using System.Collections;
using UnityEngine;

public class FreezeBox : MonoBehaviour
{
    private bool _frozen;
    void OnTriggerEnter2D(Collider2D collider2D)
    {
        GameObject ball = collider2D.gameObject;
        if(collider2D.CompareTag("Ball") && !_frozen)
        {
            Rigidbody2D ballRB = ball.GetComponent<Rigidbody2D>();
            ballRB.linearVelocity = Vector2.zero;
            
            StartCoroutine(FreezeBall(ballRB));

        }
    }
    private IEnumerator FreezeBall(Rigidbody2D ballRB)
    {
        _frozen = true;
        ballRB.bodyType = RigidbodyType2D.Static;
        yield return new WaitForSeconds(1);
        ballRB.bodyType = RigidbodyType2D.Dynamic;
        yield return new WaitForSeconds(1);
        _frozen = false;

    }
}
