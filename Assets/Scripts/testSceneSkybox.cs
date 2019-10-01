using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testSceneSkybox : MonoBehaviour
{
    [ExecuteInEditMode]

    public Material Skybox;

    private void Start()
    {
        RenderSettings.skybox = Skybox;
    }
}
