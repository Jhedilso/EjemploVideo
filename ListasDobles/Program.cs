using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListasDobles
{
    class Program
    {
        class Nodo { 
            public int dato;
            public Nodo siguiente; 
            public Nodo atras;
        }
        static void Main(string[] args)
        {
            Nodo primero = null, ultimo = null;
            int opcion_menu = 0, nuevoDato, datoBuscado, datoModificacion, datoEliminar;
            do
            {
                Console.Write("\n|---------------------------------------|"); 
                Console.Write("\n|               LISTA DOBLE             |");
                Console.Write("\n|--------------------|------------------|"); 
                Console.Write("\n| 1. Insertar Inicio | 5. Eliminar      |");
                Console.Write("\n| 2. Insertar Final  | 6. Mostrar P.U   |");
                Console.Write("\n| 3. Buscar          | 7. Mostrar U.P   |"); 
                Console.Write("\n| 4. Modificar       | 8. Salir         |");
                Console.Write("\n|--------------------|------------------|"); 
                Console.Write("\n\n Escoja una Opcion: ");
                opcion_menu = int.Parse(Console.ReadLine());
                switch (opcion_menu)
                {
                    case 1: Console.Write("\n\nINSERTAR UN DATO AL INICIO DE LA LISTA \n\n");
                        Console.Write("Ingrese el nuevo dato que se va a insertar en la lista: "); 
                        nuevoDato = int.Parse(Console.ReadLine()); 
                        insertarDatoAlInicio(ref primero,ref ultimo, nuevoDato); 
                        break;
                    case 2: Console.Write("\n\nINSERTAR UN DATO AL FINAL DE LA LISTA \n\n"); 
                        Console.Write("Ingrese el nuevo dato que se va a insertar en la lista: ");
                        nuevoDato = int.Parse(Console.ReadLine()); 
                        insertarDatoAlFinal(ref primero, ref ultimo, nuevoDato);
                        break;
                    case 3: Console.Write("\n\nBUSCAR UN DATO EN LA LISTA \n\n"); 
                        Console.Write("Ingrese el dato que se quiere buscar: "); 
                        datoBuscado = int.Parse(Console.ReadLine());
                        buscarDato(primero, datoBuscado);
                        break;
                    case 4: Console.Write("\n\nMODIFICAR UN DATO DE LA LISTA \n\n");
                        Console.Write(" Ingrese el dato que se quiere modificar en la lista: "); 
                        datoBuscado = int.Parse(Console.ReadLine()); 
                        Console.Write("\n Ingrese el nuevo dato con el que se va a reemplazar: ");
                        datoModificacion = int.Parse(Console.ReadLine());
                        modificarDato(primero, datoBuscado, datoModificacion); 
                        break;
                    case 5: Console.Write("\n\nELIMINAR UN DATO DE LA LISTA \n\n");
                        Console.Write("Ingrese el dato que se quiere eliminar: ");
                        datoEliminar = int.Parse(Console.ReadLine()); 
                        eliminarDato(ref primero, ref ultimo, datoEliminar); break;
                    case 6: Console.Write("\n\nMOSTRAR LISTA DESDE EL PRINCIPIO HASTA EL FINAL\n\n"); 
                        Console.Write("La lista enlazada desde el principio hasta el final es: ");
                        MostrarListaPrimeroUltimo(primero);
                        break;
                    case 7: Console.Write("\n\nMOSTRAR LISTA DESDE EL FINAL HASTA EL PRINCIPIO\n\n"); 
                        Console.Write("La lista enlazada desde el final hasta el principio es: ");
                        MostrarListaUltimoPrimero(ultimo); 
                        break;
                    case 8: Console.Write("\n\nPROGRAMA FINALIZADO\n\n"); 
                        break;
                    default: Console.Write("\n\nOPCION INCORRECTA \n\n"); break;
                }
            } while (opcion_menu != 8);
        }
        static void insertarDatoAlInicio(ref Nodo primero,ref Nodo ultimo, int nuevoDato) //Ingreso antes del primero
        {    
            Nodo nuevo = new Nodo();  
            nuevo.dato = nuevoDato;  
            nuevo.atras = null;
            nuevo.siguiente = primero;  
            if (primero != null)   
                primero.atras = nuevo;  
            else     ultimo = nuevo;   
            primero = nuevo;   
        }    
        static void insertarDatoAlFinal(ref Nodo primero, ref Nodo ultimo, int nuevoDato) // Ingreso después del último
        {   
            Nodo nuevo = new Nodo();
            nuevo.dato = nuevoDato;  
            nuevo.siguiente = null;   
            if (primero == null)   
            {     primero = nuevo;  
                ultimo = primero;   
            }   
            else   
            {    
                ultimo.siguiente = nuevo;  
                nuevo.atras = ultimo;  
                ultimo = nuevo;   
            }   
        }  
        static void buscarDato(Nodo primero, int datoBuscado)  
        {   
            int contador = 0;  
            if (primero != null) 
            {   
                while (primero != null)
                {
                    if (primero.dato == datoBuscado)
                        contador++;
                    primero = primero.siguiente;
                }
            }
            else
                Console.Write("\nLa lista no tiene datos.\n\n");
            if (contador == 0)
                Console.Write("\nEl dato " + datoBuscado + " no fue encontrado.\n"); 
            else if (contador == 1)
                Console.Write("\nEl dato " + datoBuscado + " fue encontrado " + contador + " vez.\n");
            else 
                Console.Write("\nEl dato " + datoBuscado + " fue encontrado " + contador + " veces.\n");
        }
        static void modificarDato(Nodo primero, int datoBuscado, int datoModificacion)
        { 
            int contador = 0;
            if (primero != null) 
            { 
                while (primero != null) 
                {
                    if (primero.dato == datoBuscado) 
                    { 
                        primero.dato = datoModificacion;
                        contador++; 
                    } 
                    primero = primero.siguiente; 
                } 
            } 
            else
                Console.Write("\nLa lista no tiene datos \n\n"); 
            if (contador == 0) 
                Console.Write("\nEl dato " + datoBuscado + " no fue encontrado.\n");
            else if (contador == 1) 
                Console.Write("\nEl dato " + datoBuscado + " fue encontrado " + contador + " vez.\n"); 
            else 
                Console.Write("\nEl dato " + datoBuscado + " fue encontrado " + contador + " veces.\n");
        }
        static void eliminarDato(ref Nodo primero, ref Nodo ultimo, int datoEliminar)
        {
            int contador = 0;
            Nodo actual = primero, anterior = null; 
            if (actual != null) 
            {
                while (actual != null) 
                { 
                    if (actual.dato == datoEliminar)
                    { 
                        if (actual == primero)
                        {
                            if (primero == ultimo) 
                            { 
                                primero = null;
                                ultimo = null; 
                            } 
                            else 
                            { 
                                primero = primero.siguiente; 
                                primero.atras = null; 
                            } 
                        }
                        else if (actual == ultimo)
                        {
                            anterior.siguiente = null; 
                            ultimo = anterior; 
                        }
                        else 
                        { 
                            anterior.siguiente = actual.siguiente; 
                            actual.siguiente.atras = anterior; 
                        } 
                        contador++;
                    } 
                    anterior = actual; 
                    actual = actual.siguiente; 
                } anterior = null; 
            }
            else
                Console.Write("\n La lista no tiene datos\n\n");
            if (contador == 0)
                Console.Write("\nEl dato " + datoEliminar + " no fue encontrado.\n");
            else if (contador == 1)
                Console.Write("\nEl dato " + datoEliminar + " fue encontrado " + contador + " vez.\n");
            else
                Console.Write("\nEl dato " + datoEliminar + " fue encontrado " + contador + " veces.\n");
        }
        static void MostrarListaPrimeroUltimo(Nodo primero) 
        { 
            Console.Write("null <-> ");
            while (primero != null)
            { 
                Console.Write(primero.dato + " <-> ");
                primero = primero.siguiente; 
            } 
            Console.WriteLine("null");
        }
        static void MostrarListaUltimoPrimero(Nodo ultimo) 
        { 
            Console.Write("null <-> ");
            while (ultimo != null) 
            {
                Console.Write(ultimo.dato + " <-> "); 
                ultimo = ultimo.atras; 
            } 
            Console.WriteLine("null");
        }
    }
}
