using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBall : MonoBehaviour {


    public GameObject ball;
    public float power = 1500f;   //定义一个力
    public float moveSpeed = 5;
    float xPosition = 0;
    float yPosition = 0;
    bool isAuto = false;
    float tmpTime = 0;


    void Start()
    {
        xPosition = this.transform.position.x;
        yPosition = this.transform.position.y;
    }

    void Update()
    {
        //由于镜头可以转动，不能根据轴来运动
        if(Input.GetKey(KeyCode.A))
        {
            xPosition += 0.1f;
        }
        else if(Input.GetKey(KeyCode.D))
        {
            xPosition -= 0.1f;
        }
        else if (Input.GetKey(KeyCode.W))
        {
            yPosition += 0.1f;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            yPosition -= 0.1f;
        }
        xPosition= Mathf.Clamp(xPosition, -15, 15);
        yPosition= Mathf.Clamp(yPosition, 0, 25);
        this.transform.position = new Vector3(xPosition, yPosition, this.transform.position.z);
        //float horizontal = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        //float vertical = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
        //transform.Translate(horizontal, vertical, 0);
        if(Input.GetKey(KeyCode.F))
        {
            if(isAuto==true)
            {
                isAuto = false;
            }
            else
            {
                isAuto = true;
            }
        }

        if (!isAuto)
        {
            if (Input.GetButtonUp("Fire1"))
            {
                GameObject instance = (GameObject)Instantiate(ball, transform.position, transform.rotation);
                instance.GetComponent<Rigidbody>().AddForce(transform.forward * power);
                StartCoroutine(Destory(instance));
            }
        }
        else
        {
            tmpTime += Time.deltaTime;
            if(tmpTime>1.5f)
            {
                GameObject instance = (GameObject)Instantiate(ball, transform.position, transform.rotation);
                instance.GetComponent<Rigidbody>().AddForce(transform.forward * power);
                StartCoroutine(Destory(instance));
                tmpTime = 0;
            }
        }
    }


    IEnumerator Destory(GameObject tmp)
    {
        yield return new WaitForSeconds(15);
        Destroy(tmp);
    }
}
