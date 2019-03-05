using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    Vector3 Midpos = new Vector3(0,0,0);
    Vector3 Rightpos = new Vector3(4,0,0);
    Vector3 Leftpos = new Vector3(-4,0,0);
    float time = 0f;

    Vector3 incPlatforms = new Vector3(0,0,5f);

    Vector3 scale = new Vector3(3,1,5);

    public Material mat;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < 10; ++i)
        {
            addPlatform(Midpos, scale);
            addPlatform(Leftpos, scale);
            addPlatform(Rightpos, scale);
            Midpos += incPlatforms;
            Rightpos += incPlatforms;
            Leftpos += incPlatforms;
        }
    }

    private void addPlatform(Vector3 position, Vector3 scale)
    {
        GameObject obj = GameObject.CreatePrimitive(PrimitiveType.Cube);
        obj.AddComponent<Platform>();
        obj.GetComponent<Renderer>().material = mat;
        Platform platform = obj.GetComponent<Platform>();
        platform.setPlatform(position, scale);
    }

    void Update()
    {
        time += Time.deltaTime;
    }
}
