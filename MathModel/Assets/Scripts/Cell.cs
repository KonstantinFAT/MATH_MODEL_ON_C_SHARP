using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    // Поля класса
    private string name_obj = "Cell";
    public double x, y, z; // координаты клетки
    public double permeability; // проницаемость клетки
    public double C = 0; // концентрация вещества
    public double p; // атмосферное давление
    public double temp; // температура среды
}
