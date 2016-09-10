using UnityEngine;
using System.Collections;

public class DiamondSquare : MonoBehaviour {
    public float[,] heights;
    public int size;
    public DiamondSquare(int size)
    {
        this.heights = new float[size, size];

        this.heights[0, 0] = 0;
        this.heights[0, size-1] = 0;
        this.heights[size-1, 0] = 0;
        this.heights[size-1, size-1] = 0;
    }

    public void PerformDiamond()
    {

    }

    public void PerformSquare()
    {

    }
}
