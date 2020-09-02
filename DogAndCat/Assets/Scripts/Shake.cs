using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class Shake : MonoBehaviour
{
    public float magn, rough, fadeIn = 0.1f, fadeOut = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        CameraShakeInstance c = CameraShaker.Instance.ShakeOnce(magn, rough, fadeIn, fadeOut);
    }
}
