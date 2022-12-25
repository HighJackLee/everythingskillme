using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneControll : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-0.035f, 0, 0);

        if (PlayerControll.isAir1 != false)
        {
            GameObject director = GameObject.Find("GameDirector");
            director.GetComponent<GameDirector>().DecreaseHp();
            Destroy(gameObject);
            PlayerControll.isAir1 = false;
        }
        else if (transform.position.x < -10)//벽을 지나면 파괴
        {
            Destroy(gameObject);
        }
    }
}
