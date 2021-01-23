using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    private Rigidbody corps;
    public GameObject Balle;
    float Force_Balle = 1000;
    public float timer_balle = .5f;
    public float distance;
    private float timer;
    private bool peut_tirer = true;
    Vector3 position;
    private bool tourne = false;

    private Quaternion rotPrecedente;

    private Vector3 direction;
    // Start is called before the first frame update
    void Start()
    {
        timer = timer_balle;

    }

    // Update is called once per frame
    void Update()
    {
        
        
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            peut_tirer = true;
            timer = timer_balle;
        }

        if (Input.GetMouseButton(1) && peut_tirer)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            transform.parent.GetComponent<Personnage>().tire = true;
            
            if (Physics.Raycast(ray, out hit, 1000))
            {
                if (!hit.collider.gameObject.name.Contains("Joueur"))
                {
                    position = hit.point;
                    //print(targetPosition.ToString() + "," + lookAtTarget);
                }
            }
            direction = new Vector3(position.x - transform.position.x, transform.parent.transform.position.y, position.z - transform.position.z);
            transform.parent.transform.LookAt(direction);
            lancer_projectile();

        }

    }

    private void lancer_projectile()
    {
        GameObject balleTemp = Instantiate(Balle, transform.position, Quaternion.identity);

        direction.y = 0;
        direction.Normalize();
        balleTemp.GetComponent<Rigidbody>().AddForce(direction * Force_Balle);

        Destroy(balleTemp, 10.0f);
        peut_tirer = false;
        transform.parent.GetComponent<Personnage>().tire = false;
    }
}
