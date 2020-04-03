using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform ball;
    public float speed;
    public float maxLeft, maxRight;
    Vector3 ballPosX;

    // Update is called once per frame
    void Update()
    {
        ballPosX = new Vector3(ball.position.x, transform.position.y, transform.position.z); // Позиция шара 
    }

    private void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position , ballPosX, speed * Time.fixedDeltaTime); // Движение объекта
    }
}
