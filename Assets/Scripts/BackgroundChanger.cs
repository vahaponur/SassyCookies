using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundChanger : MonoBehaviour
{
    private Camera cam;

    [SerializeField] private Color[] colors;
    // Start is called before the first frame update
    void Start()
    {
        int random = Random.Range(0, colors.Length);
        cam = GetComponent<Camera>();
        cam.backgroundColor = colors[random];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
