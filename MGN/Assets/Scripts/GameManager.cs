using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameManager
{
    public static float tiempoDeJuego = 0f;
    public static bool juegoEnPausa = false;
    public static int cantidadBebidas = 3;

    // Zonas de clientes
    public static float[] zonasPedirP0 = { -11.9f, -10.2f, -8.0f, -6.16f, 2.36f, 3.21f, 4.12f, 4.97f };
    public static bool[] zonasPedirP0b = { false, false, false, false, false, false, false, false };
    public static float[] zonasBaileP0 = { -13.4f, -4.78f, -0.79f};
    public static bool[] zonasBaileP0b = { false, false, false};

    public static float[] zonasPedirP1 = { -11.9f, -10.2f, -8.0f, -6.16f, 2.36f, 3.21f, 4.12f, 4.97f };
    public static bool[] zonasPedirP1b = { false, false, false, false, false, false, false, false };
    public static float[] zonasBaileP1 = { -13.4f, -4.78f, -0.79f };
    public static bool[] zonasBaileP1b = { false, false, false };

    public static float[] zonasPedirP2 = { -11.9f, -10.2f, -8.0f, -6.16f, 2.36f, 3.21f, 4.12f, 4.97f };
    public static bool[] zonasPedirP2b = { false, false, false, false, false, false, false, false };
    public static float[] zonasBaileP2 = { -13.4f, -4.78f, -0.79f };
    public static bool[] zonasBaileP2b = { false, false, false };

    // Zonas de enemigos
    public static float rangoMinP0 = 0.09f;
    public static float rangoMaxP0 = 7.47f;

    public static float rangoMinP1 = 0.09f;
    public static float rangoMaxP1 = 7.47f;
}
