using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    Vector3 dir;
    private Rigidbody bodyRef;
    // Start is called before the first frame update

    //vitesse de rotation
    void Start()
    {
       bodyRef = GetComponent<Rigidbody>();        
    }

    // Update is called once per frame
    void Update()
    {
        Input.GetAxis("Horizontal");

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");


        //appeler apres avoir declarer horizonta et vertical sinon ca marche pas 
         dir = new Vector3(horizontal,0,vertical);  

        dir = dir.normalized;
        //
        if(dir.magnitude!=0)
        {
          Quaternion q = Quaternion.LookRotation(dir);
          bodyRef.MoveRotation(q);
            
        }

        //On calcule une orientation vers 


        Debug.DrawRay(transform.position, dir *5, Color.red);


    }

   private void FixedUpdate() 
    {
        //bodyRef.MovePosition(transform.position + speed * Time.deltaTime * dir);
        bodyRef.velocity = dir *speed;
            
    }
}
