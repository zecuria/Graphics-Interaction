using UnityEngine;
using System.Collections;

public class DiamondSquare {
    public float[,] heights;
    public int size;
    public DiamondSquare(int size)
    {
        this.size = size;
        this.heights = new float[this.size, this.size];

        for (int i=0; i<size; i++)
        {
            for (int j = 0; j<size; j++)
            {
                this.heights[i, j] = 0.0f;
            }
        }

        this.PerformDiamondSquare();
    }

    public void PerformDiamondSquare()
    {
        Debug.Log(this.size);
        int sizeStep = this.size - 1;
        float scale = 1.0f / this.size;
        this.heights[0, this.size -1] = getRandom(scale);
        this.heights[0, 0] = getRandom(scale);
        this.heights[this.size - 1, 0] = getRandom(scale);
        this.heights[this.size - 1, this.size - 1] = getRandom(scale);

        while(sizeStep>=2)
        {
            int stepHalf = sizeStep / 2;
            int i = 0;
            while(i<this.size-1)
            {
                int j = 0;
                while (j < this.size - 1)
                {
                    float topLeft = this.heights[i, j];
                    float topRight = this.heights[i + sizeStep, j];
                    float bottomLeft = this.heights[i, sizeStep + j];
                    float bottomRight = this.heights[sizeStep + i, sizeStep + j];

                    float middle = (topLeft + topRight + bottomLeft + bottomRight) + getRandom(scale);

                    this.heights[i + stepHalf, j + stepHalf] = middle;
                    j += sizeStep;
                }
                i += sizeStep;
            }
            i = 0;
            while(i<this.size-1)
            {
                int j = 0;
                while (j<this.size-1)
                {
                    float topLeft = this.heights[i, j];
                    float topRight = this.heights[i + sizeStep, j];
                    float bottomLeft = this.heights[i, sizeStep + j];
                    float bottomRight = this.heights[sizeStep + i, sizeStep + j];
                    float middle = this.heights[stepHalf + i, stepHalf + j];

                    float middleTop = (topLeft + middle + topRight) / 3 + getRandom(scale);
                    this.heights[i + stepHalf, j] = middleTop;

                    float middleLeft = (topLeft + bottomLeft + middle) / 3 + getRandom(scale);
                    this.heights[i, j + stepHalf] = middleLeft;

                    float middleRight = (middle + topRight + bottomRight) / 3 + getRandom(scale);
                    this.heights[i + stepHalf + stepHalf, j + stepHalf] = middleRight;

                    float middleBottom = (middle + bottomLeft + bottomRight) / 3 + getRandom(scale);
                    this.heights[i + stepHalf, j + stepHalf + stepHalf] = middleBottom;

                    j += sizeStep;
                }
                i += sizeStep;
            }
            sizeStep /= 2;

            scale *= 1.6f;
            Debug.Log(scale);

            for(int j=0; j<this.size;j++)
            {
                for (i = 0; i < this.size; i++)
                {
                    float average = 0.0f;
                    float times = 0.0f;
                    if (i - 1 >= 0)
                    {
                        average += this.heights[i - 1, j];
                        times++;
                    }
                    if (i + 1 < this.size - 1)
                    {
                        average += this.heights[i + 1, j];
                        times++;
                    }
                    if (j - 1 >= 0)
                    {
                        average += this.heights[i, j - 1];
                        times++;
                    }
                    if (j + 1 < this.size - 1)
                    {
                        average += this.heights[i, j + 1];
                        times++;
                    }

                    if (i - 1 >= 0 && j - 1 >= 0)
                    {
                        average += this.heights[i - 1, j - 1];
                        times++;
                    }
                    if (i + 1 < this.size && j - 1 >= 0) 
                    {
                        average += this.heights[i + 1, j - 1];
                        times++;
                    }
                    if (i - 1 >= 0 && j + 1 < this.size) 
                    {
                        average += this.heights[i - 1, j + 1];
                        times++;
                    }
                    if (i + 1 < this.size && j + 1 < this.size) 
                    {
                        average += this.heights[i + 1, j + 1];
                        times++;
                    }

                    average += this.heights[i, j];
                    times++;

                    average /= times;

                    this.heights[i, j] = average;
                }
            }
        }

    }

    public float getRandom(float scale)
    {
        return Random.Range(-1*scale, scale) ;
    }
}
