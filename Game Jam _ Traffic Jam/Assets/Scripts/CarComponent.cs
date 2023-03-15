using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class CarComponent : MonoBehaviour
{
    private float timer=0;
    private float timeToChangeRoad = 4;
    private float nowpositiony;
    private int direction=3;
    public float moveSpeed;
    public float maxSpeed;
    public float RotateSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (moveSpeed < maxSpeed)
        {
            moveSpeed += (Time.deltaTime*0.5f);
        }
        this.transform.position = new Vector3(this.transform.position.x - moveSpeed, this.transform.position.y, 0);
        timer += Time.deltaTime;
        //Debug.Log(timer);
        if (timer >= timeToChangeRoad)
        {
            ChangeRoad();
        }
        if (direction == 0)
        {
            if(this.transform.position.y >= -17.5)
            {
                this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - RotateSpeed, 0);
                if (Mathf.Abs(nowpositiony - this.transform.position.y) >= 7)
                {
                    direction = 3;
                    this.transform.rotation = Quaternion.Euler(0, 0, 0);
                }
            }
        }
        if (direction==1)
        {
            if (this.transform.position.y <= 17.5)
            {
                this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + RotateSpeed, 0);
                if (Mathf.Abs(nowpositiony - this.transform.position.y) >= 7)
                {
                    direction = 3;
                    this.transform.rotation = Quaternion.Euler(0, 0, 0);
                }
            } 
        }
    }

    private void ChangeRoad()
    {
        direction = Random.Range(0, 2);
        timeToChangeRoad = Random.Range(3,7);
        if(direction== 0)
        {
            if (this.transform.position.y <= -17.49)
            {
                this.transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else TurnLeft();
        }
        else
        {
            if (this.transform.position.y >= 17.49)
            {
                this.transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else TurnRight();
        }
        timer = 0;
    }

    private void TurnLeft()
    {
        nowpositiony = this.transform.position.y;
        this.transform.rotation = Quaternion.Euler(0, 0, 20);
    }
    private void TurnRight()
    {
        nowpositiony = this.transform.position.y;
        this.transform.rotation = Quaternion.Euler(0, 0, -20);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.GetComponent<SUVComponent>() != null)
        {
            moveSpeed = -0.15f;
        }
        if (collision.gameObject.GetComponent<ChildrenComponent>() != null)
        {
            moveSpeed = -0.25f;
        }
    }
}
