using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utilidades
{
    public static Vector2 ConsigueDimensiones()
    {
        float ancho, alto;
        Camera cam = Camera.main;
        alto = cam.orthographicSize * 2;
        float ratio = cam.pixelWidth / (float)cam.pixelHeight;
        ancho = alto * ratio;

        return new Vector2(ancho, alto);
    }
}
