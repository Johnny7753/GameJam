using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraComponent : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(this.transform.position.x - GameObject.FindObjectOfType<CarComponent>().GetComponent<CarComponent>().moveSpeed, 0, -10);
    }
}
