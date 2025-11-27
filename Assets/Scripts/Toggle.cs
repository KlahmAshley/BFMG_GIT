using UnityEngine;
using System.Collections;
using UnityEngine.Rendering.Universal;
using UnityEngine.Rendering.PostProcessing;

public class Toggle : MonoBehaviour
{
    public GameObject Hair;
    public GameObject mainPlat;
    public GameObject subPlat1;
    public GameObject subPlat2;
    public GameObject subPlat3;
    public GameObject subPlat4;
    public GameObject subPlat5;
    public GameObject subPlat6;
    public GameObject subPlat7;
    public GameObject subPlat8;
    public GameObject subPlat9;
    public GameObject subPlat10;

    public Material Base;
    public Material Diffuse;
    public Material DiffuseAmbient;
    public Material Specular;
    public Material ToonShader;

    public GameObject Lut1;
    public GameObject Lut2;
    public GameObject Lut3;

    public Material Texture1;
    public Material Texture2;
    public Material base1;
    public Material base2;



    void Start()
    {
        // _Material = takenfrom.GetComponent<MeshRenderer>().material;
        Hair.GetComponent<SkinnedMeshRenderer>().material = Base;

        Lut1.SetActive(false);
        Lut2.SetActive(false);
        Lut3.SetActive(false);
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

        if (Input.GetKeyDown(KeyCode.L))
        {
            mainPlat.GetComponent<MeshRenderer>().material = base1;
            subPlat1.GetComponent<MeshRenderer>().material = base2;
            subPlat2.GetComponent<MeshRenderer>().material = base2;
            subPlat3.GetComponent<MeshRenderer>().material = base2;
            subPlat4.GetComponent<MeshRenderer>().material = base2;
            subPlat5.GetComponent<MeshRenderer>().material = base2;
            subPlat6.GetComponent<MeshRenderer>().material = base2;
            subPlat7.GetComponent<MeshRenderer>().material = base2;
            subPlat8.GetComponent<MeshRenderer>().material = base2;
            subPlat9.GetComponent<MeshRenderer>().material = base2;
            subPlat10.GetComponent<MeshRenderer>().material = base2;

        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            mainPlat.GetComponent<MeshRenderer>().material = Texture1;
            subPlat1.GetComponent<MeshRenderer>().material = Texture2;
            subPlat2.GetComponent<MeshRenderer>().material = Texture2;
            subPlat3.GetComponent<MeshRenderer>().material = Texture2;
            subPlat4.GetComponent<MeshRenderer>().material = Texture2;
            subPlat5.GetComponent<MeshRenderer>().material = Texture2;
            subPlat6.GetComponent<MeshRenderer>().material = Texture2;
            subPlat7.GetComponent<MeshRenderer>().material = Texture2;
            subPlat8.GetComponent<MeshRenderer>().material = Texture2;
            subPlat9.GetComponent<MeshRenderer>().material = Texture2;
            subPlat10.GetComponent<MeshRenderer>().material = Texture2;
        }


        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            Lut1.SetActive(true);
            Lut2.SetActive(false);
            Lut3.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            Lut1.SetActive(false);
            Lut2.SetActive(true);
            Lut3.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            Lut1.SetActive(false);
            Lut2.SetActive(false);
            Lut3.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            Lut1.SetActive(false);
            Lut2.SetActive(false);
            Lut3.SetActive(false);
        }
    }
}
