using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneControll2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < 0)
        {
            transform.Translate(0.03f, -0.01f, 0);
        }
        else if (transform.position.x > 0)
        {
            transform.Translate(0.03f, 0.01f, 0);
        }

        if (PlayerControll.isAir != false)
        {
            GameObject director = GameObject.Find("GameDirector");
            director.GetComponent<GameDirector>().DecreaseHp();
            Destroy(gameObject);
            PlayerControll.isAir = false;
        }
        else if (transform.position.x > 10)//벽을 지나면 파괴
        {
            Destroy(gameObject);
        }
    }
}
