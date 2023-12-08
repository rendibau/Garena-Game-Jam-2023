using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;  // Referensi ke transform karakter yang diikuti
    public float smoothSpeed = 0.125f;  // Kecepatan perpindahan kamera

    void LateUpdate()
    {
        if (target != null)
        {
            // Mendapatkan posisi target
            Vector3 desiredPosition = new Vector3(target.position.x, target.position.y, transform.position.z);

            // Menghitung posisi yang diinginkan dengan efek smoothing
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

            // Mengatur posisi kamera ke posisi yang dihitung
            transform.position = smoothedPosition;
        }
    }
}
