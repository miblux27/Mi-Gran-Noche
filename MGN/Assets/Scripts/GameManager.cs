using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameManager
{
    public static float tiempoDeJuego = 0f;
    public static bool juegoEnPausa = false;
    public static int cantidadBebidas = 3;

    // Zonas de clientes
    public static float[] zonasPedirP0 = { -21.16f, -19.3f, -17.13f, -15.35f, -12.53f, -10.71f, -8.34f, -6.55f, 7.36f, 9.22f, 10.73f, 12.5f};
    public static bool[] zonasPedirP0b = { false, false, false, false, false, false, false, false, false, false, false, false};
    public static float[] zonasBaileP0 = { 0.09f, -13.91f, 14.08f, 4.47f, 2.38f, -4.96f};
    public static bool[] zonasBaileP0b = { false, false, false, false, false, false};

    public static float[] zonasPedirP1 = { -19.31f, 13.65f, -14.62f, -4.86f, -8.05f};
    public static bool[] zonasPedirP1b = { false, false, false, false, false};
    public static float[] zonasBaileP1 = { -11.87f, 2.14f, 10.77f, -21.62f};
    public static bool[] zonasBaileP1b = { false, false, false, false};

    /*public static float[] zonasPedirP2 = { -11.9f, -10.2f, -8.0f, -6.16f, 2.36f, 3.21f, 4.12f, 4.97f };
    public static bool[] zonasPedirP2b = { false, false, false, false, false, false, false, false };
    public static float[] zonasBaileP2 = { -13.4f, -4.78f, -0.79f };
    public static bool[] zonasBaileP2b = { false, false, false };*/

    // Zonas de enemigos
    public static float rangoMinP0 = 0.09f;
    public static float rangoMaxP0 = 13.72f;

    public static float rangoMinP1 = 0.09f;
    public static float rangoMaxP1 = 7.47f;
}
