using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControll : MonoBehaviour
{
    Rigidbody2D rigid2D;
    Animator animator;
    float jumpForce = 600.0f;
    float walkForce = 20.0f;
    float maxWalkSpeed = 2.5f;
    bool isGround = false;
    public static bool isBeetle = false;
    public static bool isBus = false;
    public static bool isAir = false;
    public static bool isAir1 = false;

    // Start is called before the first frame update
    void Start()
    {
        this.rigid2D = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // 점프!
        if (isGround)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                if(isGround != false)
                {
                    this.animator.SetTrigger("JumpTrigger");
                    this.rigid2D.AddForce(transform.up * this.jumpForce);
                    isGround = false;
                }
            }
        }

        // 플레이어 이동
        int key = 0;
        if (Input.GetKey(KeyCode.RightArrow)) key = 1;
        if (Input.GetKey(KeyCode.LeftArrow)) key = -1;

        // 플레이어 이동속도
        float speedx = Mathf.Abs(this.rigid2D.velocity.x);

        // 이동속도 제한
        if (speedx < this.maxWalkSpeed)
        {
            this.rigid2D.AddForce(transform.right * key * this.walkForce);
        }

        // 움직이는 방향에 따라 반전
        if (key != 0)
        {
            transform.localScale = new Vector3(key, 1, 1);
        }

        // 플레이어의 속도에 맞춰 애니메이션 속도 변경
        if (this.rigid2D.velocity.y == 0)
        {
            this.animator.speed = speedx / 2.0f;
        }
        else
        {
            this.animator.speed = 1.0f;
        }

        //플레이어가 화면 밖으로 나간다면 처음으로
        if (transform.position.y < -10)
        {
            SceneManager.LoadScene("MainScene");
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            Debug.Log("발판 위 도착");
            isGround = true;
        } else if(other.gameObject.tag == "Bomb")// 장애물과 부딪힘
        {
            Debug.Log("체력감소");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "beetle")
        {
            isBeetle = true;
        }
        else if (other.gameObject.tag == "bus")
        {
            isBus = true;
        }
        else if (other.gameObject.tag == "air")
        {
            isAir = true;
        }
        else if (other.gameObject.tag == "air1")
        {
            isAir1 = true;
        }
    }
}
