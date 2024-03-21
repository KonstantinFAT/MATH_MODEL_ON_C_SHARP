using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson1_1
{
    class Cell
    {
        // Поля класса
        protected string name_obj = "Cell";
        public double x, y, z; // координаты клетки
        public double permeability; // проницаемость клетки
        public double C = 0; // концентрация вещества
        public double p; // атмосферное давление
        public double temp; // температура среды

        // Методы класса
        public void show_cell_parameters()
        {
            Console.WriteLine("Координаты: "+x+", "+y+", "+z);
            Console.WriteLine("Концентрация вещества: "+C);
            Console.WriteLine();
        }
    } // Класс клетки базовой
    class Land : Cell // Класс клетки земли
    {
        // Поля класса
        protected string name_obj = "Cell_of_land";
        protected double permeability = 0; // проницаемость клетки
    }
    class Struct : Cell // Класс клетки постройки
    {
        // Поля класса
        protected string name_obj = "Cell_of_structure";
        protected double permeability; // проницаемость клетки
    }
    internal class Program
    {
        static void make_structure(int coord_z, int coord_y, int coord_x, int z_width,int y_height,int x_length, Cell [,,] arr) // Метод для создания и помещения непроницаемых объектов (постройки)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    for(int k = 0; k < arr.GetLength(2); k++)
                    {
                        {
                            if ((i >= coord_z && i <= (coord_z+z_width)) && (j >= (coord_y - y_height) && j <= coord_y) && (k >= coord_x && k <= (coord_x + x_length))) // Проверка левой верхней крайней точки объекта
                            {
                                arr[i, j, k] = new Struct();
                            }
                        }
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            // Создание трехмерной сетки
            // Определение границ
            Console.WriteLine("Введите граничное значение по оси X:");
            double oX = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Введите граничное значение по оси Y:");
            double oY = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Введите граничное значение по оси Z:");
            double oZ = Convert.ToDouble(Console.ReadLine());
            // Определение шага по оси
            Console.WriteLine("Введите значение шага по оси:"); // пока примем, что шаги по осям равны между собой
            double axis_step = Convert.ToDouble(Console.ReadLine());
            // Определение количества точек по осям
            int X = Convert.ToInt32(oX / axis_step);
            int Y = Convert.ToInt32(oY / axis_step);
            int Z = Convert.ToInt32(oZ / axis_step);
            Cell [,,] grid = new Cell [Z, Y, X];
            // Помещение внутрь сетки объектов класса Cell и Cell_of_land_or_mount
            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    for(int k = 0; k < grid.GetLength(2); k++)
                    {
                        if (j == (grid.GetLength(1)-1))
                        {
                            grid[i, j, k] = new Land();
                            grid[i, j, k].x = k * axis_step;
                            grid[i, j, k].y = j * axis_step;
                            grid[i, j, k].z = i * axis_step;
                        }
                        else
                        {
                            grid[i, j, k] = new Cell();
                            grid[i, j, k].x = k * axis_step;
                            grid[i, j, k].y = j * axis_step;
                            grid[i, j, k].z = i * axis_step;
                        }
                    }
                }
            }
            make_structure(1, 2, 2, 1, 1, 1, grid);
            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    for (int k = 0; k < grid.GetLength(2); k++)
                    {
                        Console.Write(grid[i, j, k].GetType().Name + " ");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine("-------------------------");
            }



        }
    }
}
