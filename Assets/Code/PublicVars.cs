using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PublicVars
{
    public static Dictionary<string, bool> items = new Dictionary <string, bool>
    {
        {"goggles", false},
        {"boots", true},
        {"chalice", false},
        {"bow", true},
        {"key", false},
        {"bridge", false}
    };

    public static int playerHealth = 3;

}
