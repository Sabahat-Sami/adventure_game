using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PublicVars
{
    public static Dictionary<string, bool> items = new Dictionary <string, bool>
    {
        {"goggles", false},
        {"boots", false},
        {"chalice", false},
        {"bow", false},
        {"key", false},
        {"bridge", false}
    };

    public static int playerHealth = 3;

}
