using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameManager
{
    public static float tiempoDeJuego = 0f;
    public static bool juegoEnPausa = false;
    public static int cantidadBebidas = 3;

    public static float[] zonasDisponibles = { -11.9f, -10.2f, -8.0f, -6.16f, 2.36f, 3.21f, 4.12f, 4.97f };
    public static bool[] zonasOcupadas = { false, false, false, false, false, false, false, false };

    public static float[] zonasDeBaile = { -13.4f, -4.78f, -0.79f};
    public static bool[] zonasDeBaileOcupadas = { false, false, false};
}
