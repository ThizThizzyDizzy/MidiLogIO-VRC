using UdonSharp;
using UnityEngine;

public class Floor : UdonSharpBehaviour
{
    public MeshRenderer floor;
    public Material red;
    public Material blue;

    public void Blue()
    {
        floor.material = blue;
    }

    public void Red()
    {
        floor.material = red;
    }
}
