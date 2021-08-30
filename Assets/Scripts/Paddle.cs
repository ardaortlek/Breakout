using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float screenWidth = 16f;
    [SerializeField] float maxUnit = 15f;
    [SerializeField] float minUnit = 1f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 paddleNewPos = new Vector2(Mathf.Clamp(Input.mousePosition.x / Screen.width * screenWidth, minUnit, maxUnit), transform.position.y);
        transform.position = paddleNewPos;
    }
}
