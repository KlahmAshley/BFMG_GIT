using UnityEngine;
using System.Collections;
using UnityEngine.Rendering.Universal;
using UnityEngine.Rendering.PostProcessing;

public class Toggle : MonoBehaviour
{
    public GameObject Hair;
  
    public Material Base;
    public Material Diffuse;
    public Material DiffuseAmbient;
    public Material Specular;
    public Material ToonShader;

    public GameObject Lut1;
    public GameObject Lut2;
    public GameObject Lut3; 


    void Start()
    {
        // _Material = takenfrom.GetComponent<MeshRenderer>().material;
        Hair.GetComponent<SkinnedMeshRenderer>().material = Base;

        Lut1.SetActive(false);
 
    }
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Hair.GetComponent<SkinnedMeshRenderer>().material = Base;

        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Hair.GetComponent<SkinnedMeshRenderer>().material = Diffuse;

        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Hair.GetComponent<SkinnedMeshRenderer>().material = DiffuseAmbient;

        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            Hair.GetComponent<SkinnedMeshRenderer>().material = Specular;

        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            Hair.GetComponent<SkinnedMeshRenderer>().material = ToonShader;

        }


        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            Lut1.SetActive(true);
            Lut2.SetActive(true);
            Lut3.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            Lut1.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            Lut1.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            Lut1.SetActive(true);
        }
    }
}
