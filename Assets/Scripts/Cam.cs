using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
    public GameObject joueur;
    public Vector3 offset;
    private Rigidbody corps;
    // Start is called before the first frame update
    void Start()
    {
        corps = joueur.GetComponent<Rigidbody>();
        offset = transform.position - corps.transform.position;
        //transform.Rotate(new Vector3(8, 0, 0));

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(corps.transform.position.x + offset.x, transform.position.y, corps.transform.position.z + offset.z);
    }
}
