using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    Vector3 spawnPoint;
    public Rigidbody rb;
    public GameObject controlPanel;
    public Controller count;

    // Start is called before the first frame update
    void Start()
    {
        spawnPoint = transform.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "HitObject")
        {
            count.hitObjCount -= 1;
            controlPanel.SetActive(true);
            Destroy(collision.gameObject);
            rb.velocity = Vector3.zero;
            transform.position = spawnPoint;
        }
        else if (collision.gameObject.tag == "Enemy")
        {
            controlPanel.SetActive(true);
            rb.velocity = Vector3.zero;
            transform.position = spawnPoint;
        }
    }
}
