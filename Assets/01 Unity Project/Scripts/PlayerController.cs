using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameManager GameManager;
    [SerializeField] private float speed = 8.0f;
    public GameObject character;
    public GameObject explosion;

    private Rigidbody playerRigidbody = default;
    private bool isDead = false;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();

        //Vector3 point1 = new Vector3(0, 0, 1);
        //Vector3 point2 = new Vector3(11, 12, 3);
        //float dist = (point2 - point1).magnitude;
        //Debug.Log($"두 점 사이의 거리: {dist}");
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDead)
        {
            //GetKey()로 움직이기
            //if (Input.GetKey(KeyCode.UpArrow))
            //{
            //    playerRigidbody.AddForce(new Vector3(0, 0, speed));
            //}

            //if (Input.GetKey(KeyCode.DownArrow))
            //{
            //    playerRigidbody.AddForce(new Vector3(0, 0, -speed));
            //}

            //if (Input.GetKey(KeyCode.LeftArrow))
            //{
            //    playerRigidbody.AddForce(new Vector3(-speed, 0, 0));
            //}

            //if (Input.GetKey(KeyCode.RightArrow))
            //{
            //    playerRigidbody.AddForce(new Vector3(speed, 0, 0));
            //}

            //GetAxis()로 움직이기
            float xInput = Input.GetAxis("Horizontal");
            float zInput = Input.GetAxis("Vertical");

            float xSpeed = xInput * speed;
            float zSpeed = zInput * speed;

            Vector3 velocity = new Vector3(xSpeed, 0f, zSpeed);
            playerRigidbody.velocity = velocity;
        }
    }       //Update()

    //플레이어 사망
    public void Die()
    {
        if (!isDead)
        {
            isDead = true;
            explosion.SetActive(true);
            character.SetActive(false);

            GameManager.EndGame();
        }
    }       //Die()
}