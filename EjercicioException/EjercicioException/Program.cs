using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioException
{
    class Program
    {
        static void Main(string[] args)
        {
            Terrain[] terrains = new Terrain[2];
            terrains[0] = new Terrain();
            terrains[0].building = new Building();
            terrains[0].building.name = "Granja";
            terrains[1] = new Terrain();
            
            try //Exception personalizada
            {
                Get_name(terrains);
            }
            catch (NoBuildingException e)
            {
                Console.WriteLine(e.Message);
            }

            try //Exception out of range(Perdon por el ejemplo fome)
            {
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine(terrains[i].building);
                }
            }
            catch(IndexOutOfRangeException e)
            {
                Console.WriteLine("No hay espacio en la lista terreno");
            }
            
        }
        static public void Get_name(Terrain[] terrains)
        {
            if (terrains[1].building == null)
            {
                NoBuildingException nb = new NoBuildingException(1, "El terreno 1 no tiene edificio"); //La utilidad vendria al hacerlo en un for y detectar a que index de la lista de terrenos corresponde (No solo el 1)
                throw nb;
            }
            Console.WriteLine(terrains[1].building.name);
        }
    }
    class Building
    {
        public string name;
        
    }
    class Terrain
    {
        public Building building;
        public string Get_Building_name()
        {
            return building.name;
        }
    }
    public class NoBuildingException : ApplicationException
    {
        private readonly int terrainNum;

        public int TerrainNum { get { return terrainNum; } }

        public NoBuildingException(int num, string message) : base(message)
        {
            this.terrainNum = num;
        }
    }

}
