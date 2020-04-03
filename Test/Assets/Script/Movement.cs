using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    public Rigidbody ball, cube;
    public VariableJoystick joystick;
    public Transform arrow;

    public float moveSpeed = 600f;
    public float force = 3f;
    public float minForce = 1f, maxForce = 5f;

    float movementX = 0f;
    float movementZ = 0f;

    public Vector3 minScale, maxScale;

    void Update()
    {
        movementX = joystick.Horizontal;
        movementZ = joystick.Vertical * -1;

        Force();
        
        arrow.localScale = Vector3.Lerp(minScale, maxScale, (force - 1) / 2); // Размер стрелы, не самый лучший вариан, но ничего лучше не придумал на данный момент
    }

    void Force()// Скорость удара о шар
    {
        force += movementZ;

        if (force <= minForce)
            force = minForce;
        else if (force >= maxForce)
            force = maxForce;
    }

    private void FixedUpdate()
    {
        transform.RotateAround(transform.position, Vector3.up, movementX * Time.fixedDeltaTime * -moveSpeed);// Движение куба
    }

    public void OnClickHit()// Кнопка запуска куба о шар
    {
        cube.AddRelativeForce(0, 0, force * 500);
    }
}
