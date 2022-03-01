using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{

    public GameObject yoyo;
    public Transform yoyo_yer;
     GameObject yoyo_copy;

    public GameObject target_icon;
    public Vector3 target_yer;
    public RaycastHit hit;
    public Ray lazer;
  

    public Rigidbody m_Rigidbody;
    public float m_Speed = 5f;
    float horizontalSpeed = 2.0f;
    float verticalSpeed = 2.0f;
    float h;
    float v;


    public static player instance;
    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        target_icon.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {


        h = horizontalSpeed * Input.GetAxis("Mouse Y");
        v = verticalSpeed * Input.GetAxis("Mouse X");

        if (Input.GetMouseButton(0))
        {

            target_yer = Input.mousePosition;
           

            transform.Rotate((h * m_Speed * Time.deltaTime),
                (v * m_Speed * Time.deltaTime), 0, Space.World);

            target_icon.transform.position = target_yer;
            lazer = Camera.main.ScreenPointToRay(target_yer);

            Physics.Raycast(lazer, out hit, 100);

            //Vector3 direction = body.transform.position - transform.position;
            //body.AddForceAtPosition(direction.normalized, transform.position);

            yoyo_copy = Instantiate(yoyo, yoyo_yer.transform.position, yoyo_yer.transform.rotation);
            Destroy(yoyo_copy, 3.5f);

            yoyo_copy.GetComponent<Rigidbody>().AddForce(transform.TransformDirection(new Vector3(v, 0, h)));
            Debug.Log(target_yer);

            //clone.velocity = transform.TransformDirection(Vector3.forward * 10);








        }




        //yoyo_copy = Instantiate(yoyo, yoyo_yer.position, Quaternion.identity);
        //yoyo_copy.GetComponent<Rigidbody>().AddForce(transform.forward * 1000);
    }
}
