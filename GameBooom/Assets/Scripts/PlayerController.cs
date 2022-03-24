using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float min_Speed = 5;
    public float max_Speed = 10;
    public float speed;

    public float downTime = 0;
    public float maxTime = 2;

    public bool ground = true;
    public int jumpCount;               //jumpCount是设置人物可以跳跃的次数-1(可以设置多次跳跃）

    // Start is called before the first frame update
    void Start()
    {
        speed = min_Speed;
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");  //获取角色移动
        //float v = Input.GetAxis("Vertical");

        if( h!= 0 )
        {
            Vector3 dir = new Vector3(h, 0, 0);
            Quaternion targetQ = Quaternion.LookRotation(dir, Vector3.up);
            transform.rotation = targetQ;
            downTime += Time.deltaTime;
            //实现行走
            transform.position = transform.position + transform.forward * Time.deltaTime * speed;
            //实现加速
            if(speed < max_Speed && downTime > maxTime && ground)
            {
                speed += 0.1f;
            }
            //实现跳跃

            if (ground)//isGround是判断是否在地面
            {
                jumpCount = 2;//jumpCount是设置人物可以跳跃的次数-1(可以设置多次跳跃）
            }

            if (Input.GetKeyDown(KeyCode.Space) && jumpCount > 0)//是否可以进行人物跳跃
            {
                GetComponent<Rigidbody>().velocity = Vector2.up * speed;
                ground = false;
                jumpCount--;
            }

        }
        else
        {
            downTime = 0;       //计时归零
            speed = min_Speed;  //速度回到初值
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "ground")
        {
            ground = true;
            downTime = 0;       //计时归零
        }
    }

}
