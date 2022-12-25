using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileControll : MonoBehaviour
{
    Rigidbody2D rigid2D;
    bool isGround = false;
    bool isPlayer = false;

    // Start is called before the first frame update
    void Start()
    {
        this.rigid2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isGround != false)//땅에 닿으면 파괴
        {
            Destroy(gameObject);
        }else if(isPlayer != false)
        {
            GameObject director = GameObject.Find("GameDirector");
            director.GetComponent<GameDirector>().DecreaseHp();
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            Debug.Log("폭탄 다른 물체에 닿음");
            isGround = true;
        }
        else if (other.gameObject.tag == "Player")
        {
            Debug.Log("유저와 충돌");
            isPlayer = true;
        }
    }
}
