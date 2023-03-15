using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishPoint : MonoBehaviour
{
    public GameObject FinishMenu;
    public GameObject LostMenu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.FindObjectOfType<TimerComponent>().tempTime >= 60)
        {
            Time.timeScale = 0;
            LostMenu.SetActive(true);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<CarComponent>() != null)
        {
            Time.timeScale = 0;
            FinishMenu.SetActive(true);
        }
    }

}
