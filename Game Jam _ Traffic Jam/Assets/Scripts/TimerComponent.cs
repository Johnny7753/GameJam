using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerComponent : MonoBehaviour
{
    public float tempTime=0;
    public float totalTime=0;
    private TMP_Text _tmp;
    // Start is called before the first frame update
    void Start()
    {
        _tmp = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        tempTime +=Time.deltaTime;
        _tmp.text = tempTime.ToString();

    }
}
