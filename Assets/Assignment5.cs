using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;

public class Assignment5 : MonoBehaviour
{
    public Rigidbody rigidbody;
    public GameObject gameObject;

    int[] jumperForce = {500, 1000};

    // Start is called before the first frame update
    void Start()
    {
        string name = gameObject.name;
        int number = int.Parse(Regex.Replace(name, "[^0-9]", "")) - 1;
        Debug.Log(name + " jump " + jumperForce[number]);

        rigidbody.AddForce(0, jumperForce[number], 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
