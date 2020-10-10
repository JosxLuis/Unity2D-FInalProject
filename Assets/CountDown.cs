using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour
{
    public float timeStart = 60;
    public Text textBox;
    public GameObject key;
    public Transform keyPosition;
    Boolean flag = false;
    public Player p;

    // Start is called before the first frame update
    void Start()
    {
        textBox.text = timeStart.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        timeStart -= Time.deltaTime;
        textBox.text = "Orda termina en:"+Mathf.Round(timeStart).ToString()+"s";
        
        if (timeStart <=0) {
            timeStart = 0;
            if (flag == false) {
                Instantiate(key, keyPosition.position, transform.rotation);
                flag = true;
            }
            if (p.key == true && p.door == true) {
                textBox.text = "Nivel prototipo terminado";
            }
        }
    }
}
