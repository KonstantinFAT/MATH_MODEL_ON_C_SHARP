using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CreateGrid : MonoBehaviour
{
    public float oX; // Граничное значение по оси X
    public float oY; // Граничное значение по оси Y
    public float oZ; // Граничное значение по оси Z
    public float axis_step; // Шаг по оси
    private int X; // Количества точек по оси X
    private int Y; // Количества точек по оси Y
    private int Z; // Количества точек по оси Z

    public GameObject[,,] grid;
    public GameObject cell;
    public GameObject land;
    public GameObject build;

    private void Start()
    {
        oX = 1;
        oY = 1;
        oZ = 1;
        axis_step = 0.2f;
        X = (int)Math.Ceiling(oX / axis_step);
        Y = (int)Math.Ceiling(oY / axis_step);
        Z = (int)Math.Ceiling(oZ / axis_step);
        grid = new GameObject[X, Y, Z];



        for (int i = 0; i < grid.GetLength(0); i++)
        {
            for (int j = 0; j < grid.GetLength(1); j++)
            {
                for (int k = 0; k < grid.GetLength(2); k++)
                {
                    if (j == (grid.GetLength(1) - Y))
                    {
                        grid[i, j, k] = Instantiate(land, new Vector3(k, j, i), Quaternion.identity) as GameObject;
                        grid[i, j, k].GetComponent<BoxCollider>().size = new Vector3(0.5f, 0.5f, 0.5f);
                    }
                    else
                    {
                        grid[i, j, k] = Instantiate(cell, new Vector3(k, j, i), Quaternion.identity) as GameObject;
                        grid[i, j, k].GetComponent<BoxCollider>().size = new Vector3(0.5f, 0.5f, 0.5f);

                    }

                }
            }
        }

        make_build(1,2,3,1,2,3, grid);
    }
    private void make_build(int coord_z, int coord_y, int coord_x, int z_width, int y_height, int x_length, GameObject[,,] arr)
    {
        for (int i = 0; i < arr.GetLength(0); i++)
        {
            for (int j = 0; j < arr.GetLength(1); j++)
            {
                for (int k = 0; k < arr.GetLength(2); k++)
                {
                    {
                        if ((i >= coord_z && i <= (coord_z + z_width)) && (j >= (coord_y - y_height) && j <= coord_y) && (k >= coord_x && k <= (coord_x + x_length))) // Проверка левой верхней крайней точки объекта
                        {
                            arr[i, j, k] = Instantiate(build, new Vector3(k, j, i), Quaternion.identity) as GameObject;
                        }
                    }
                }
            }
        }

    }

}

