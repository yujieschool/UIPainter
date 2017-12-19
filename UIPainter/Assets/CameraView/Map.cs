using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour {

	// Use this for initialization
	void Start () {

        rayPoints = new Vector3[4] ;

        for (int i = 0; i < 4; i++)
        {
            rayPoints[i] = Vector3.zero;
        }
		
	}


    public Vector3[] rayPoints;
	// Update is called once per frame
	void Update () {


      Ray   tmpRay=    Camera.main.ViewportPointToRay(Vector3.zero);


        RaycastHit  hit  ;

        if (Physics.Raycast(tmpRay, out hit ,1000))
        {


            rayPoints[0] = hit.point;


         //   Debug.Log("hit.point 11==" + hit.point);
             
 
        }

   

      Debug.DrawRay(tmpRay.origin,tmpRay.direction,Color.red);



      Ray tmpRay2 = Camera.main.ViewportPointToRay(Vector3.right);

      if (Physics.Raycast(tmpRay2, out hit, 1000))
      {


          rayPoints[1] = hit.point;

        //  Debug.Log("hit.point 222==" + hit.point);


      }

      Debug.DrawRay(tmpRay2.origin, tmpRay2.direction, Color.red);


      Ray tmpRay3 = Camera.main.ViewportPointToRay(Vector3.one);


      if (Physics.Raycast(tmpRay3, out hit, 1000))
      {


          rayPoints[2] = hit.point;

          //Debug.Log("hit.point 333==" + hit.point);


      }



      Debug.DrawRay(tmpRay3.origin, tmpRay3.direction, Color.red);


      Ray tmpRay4 = Camera.main.ViewportPointToRay(Vector3.up);


      if (Physics.Raycast(tmpRay4, out hit, 1000))
      {

        
          rayPoints[3] = hit.point;

       //   Debug.Log("hit.point 444==" + hit.point);


      }



      Debug.DrawRay(tmpRay4.origin, tmpRay4.direction, Color.red);
		
	}
}
