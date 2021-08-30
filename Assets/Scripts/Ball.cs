using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] Paddle paddle;
    [SerializeField] AudioClip[] sounds;

    Vector2 offSetBetweenVectors;
    bool hasStarted;
    float randomFactor = 0.2f;
    float randomAngle;
    float initialXVelocity = 2f;
    float initialYVelocity = 10f;

    // Start is called before the first frame update
    void Start()
    {
        offSetBetweenVectors = transform.position - paddle.transform.position;
        hasStarted = false;
        GetComponent<Rigidbody2D>().simulated = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted)
        {
            lockTheBall();
            launchTheBall();
        }       

    }

    private void lockTheBall()
    {
        Vector2 paddlePosition = new Vector2(paddle.transform.position.x, paddle.transform.position.y);
        transform.position = paddlePosition + offSetBetweenVectors;                
    }

    private void launchTheBall()
    {
        if (Input.GetMouseButtonDown(0))
        {
            hasStarted = true;
            GetComponent<Rigidbody2D>().simulated = true;
            GetComponent<Rigidbody2D>().velocity = new Vector2(initialXVelocity, initialYVelocity);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        AudioClip sound = sounds[Random.Range(0, sounds.Length)];
        GetComponent<AudioSource>().PlayOneShot(sound);
        randomAngle = Random.Range(-randomFactor, randomFactor);
        GetComponent<Rigidbody2D>().velocity = Quaternion.Euler(0, 0, randomAngle) * GetComponent<Rigidbody2D>().velocity;
    }
}
