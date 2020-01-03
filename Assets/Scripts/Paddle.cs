using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField]
    public float minX;
    [SerializeField]
    public float maxX;
    [SerializeField]
    public float screenWidth;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var mousePos = Input.mousePosition.x / Screen.width * screenWidth;
        
        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);

        paddlePos.x = Mathf.Clamp(mousePos, minX, maxX);

        transform.position = paddlePos;
    }
}
