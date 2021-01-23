using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personnage : MonoBehaviour
{
    private Vector3 targetPosition;
    private bool moving = false;
    private Vector3 lookAtTarget;
    private Quaternion playerRot;
    public bool tire = false;
    float rotSpeed = 5;
    float speed = 10;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            tire = false;
            changePosition();
        }
        if(moving)
        {
            Move();
        }
    }

    void changePosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, 1000) )//&& hit.collider.gameObject.name.Contains("Terrain"))
        {
            if ((Mathf.Abs(hit.point.x-transform.position.x) >= GetComponent<BoxCollider>().size.x / 2 + 1) && (Mathf.Abs(hit.point.z - transform.position.z) >= GetComponent<BoxCollider>().size.z / 2 + 1))
            {
                targetPosition = hit.point;
                lookAtTarget = new Vector3(targetPosition.x - transform.position.x, transform.position.y, targetPosition.z - transform.position.z);
                playerRot = Quaternion.LookRotation(lookAtTarget);
                moving = true;
                //print(targetPosition.ToString() + "," + lookAtTarget);
            }
        }
    }

    void Move()
    {
        if (!tire)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, playerRot, rotSpeed * Time.deltaTime);
        }
        //transform.LookAt(lookAtTarget);
        transform.position = Vector3.MoveTowards(transform.position, targetPosition + new Vector3(0, this.GetComponent<BoxCollider>().size.y, 0), speed * Time.deltaTime);
        if(transform.position == targetPosition)
        {
            moving = false;
        }
    }
}
