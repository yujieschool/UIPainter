using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMap : MonoBehaviour {

    Map tmpMap;

   public  Terrain terrainData;


    RectTransform selfTrans;
    void Start()
    {

        tmpMap = Camera.main.GetComponent<Map>();

 
          selfTrans =  transform.GetComponent<RectTransform>();
    }
    public int lineCount = 100;
    public float radius = 3.0f;

    static Material lineMaterial;
    static void CreateLineMaterial()
    {
        if (!lineMaterial)
        {
            // Unity has a built-in shader that is useful for drawing
            // simple colored things.
            Shader shader = Shader.Find("Hidden/Internal-Colored");
            lineMaterial = new Material(shader);
            lineMaterial.hideFlags = HideFlags.HideAndDontSave;
            // Turn on alpha blending
            lineMaterial.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
            lineMaterial.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
            // Turn backface culling off
            lineMaterial.SetInt("_Cull", (int)UnityEngine.Rendering.CullMode.Off);
            // Turn off depth writes
            lineMaterial.SetInt("_ZWrite", 1);
        }
    }


    public Vector2 ConvertPoints(int index)
    {

        index = index % tmpMap.rayPoints.Length;

        Vector3 tmpPos = tmpMap.rayPoints[index];



        float rateXX = tmpPos.x / terrainData.terrainData.size.x;

        float rateYY = tmpPos.z / terrainData.terrainData.size.z;


        rateXX -= 0.5f;

        rateYY -= 0.5f;

        Vector2 result = Vector2.zero;
       result.x=  selfTrans.sizeDelta.x* rateXX;

       result.y = selfTrans.sizeDelta.y * rateYY;

      // Debug.Log("index=="+index +"==reuslt=="+result);



       return result;

    }
    // Will be called after all regular rendering is done
    public void OnRenderObject()
    {
        CreateLineMaterial();
        // Apply the line material
        lineMaterial.SetPass(0);

      
        GL.PushMatrix();
        // Set transformation matrix for drawing to
        // match our transform
        GL.MultMatrix(transform.localToWorldMatrix);


        //GL.LoadOrtho();
        // Draw lines
        GL.Begin(GL.LINES);


        GL.Color(Color.red);

        for (int i = 1; i < 5; i++)
        {
   


            Vector2 front = ConvertPoints(i - 1);



            GL.Vertex3(front.x, front.y, 0);
            Vector2 back = ConvertPoints(i);

            GL.Vertex3(back.x, back.y, 0);
            
        }
 
  
        GL.End();
        GL.PopMatrix();
    }
}
