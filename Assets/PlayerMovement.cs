using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float jumpSpeed;
    public float playerSpeed;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        JumpMovement();
        //print("fixed update");
        this.GetComponent<Rigidbody>().velocity = new Vector3(playerSpeed * Time.deltaTime, GetComponent<Rigidbody>().velocity.y, GetComponent<Rigidbody>().velocity.z);
    }
    private void OnCollisionStay(Collision collision)
    {
        //Debug.Log(collision.gameObject.name);
        if (collision.gameObject.name == "Ground")
        {
            JumpMovement();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<ObstacleController>()!=null)
        {
            Destroy(this.gameObject);
        }
    }
    private void JumpMovement()
    {
        //jump movement
        if (Input.GetKeyDown(KeyCode.Space))
        {
            this.GetComponent<Rigidbody>().AddForce(new Vector3(0, jumpSpeed, 0));
            //Debug.Log("jumped");
        }
    }
}
