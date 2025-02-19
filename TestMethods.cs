using System.Collections.Generic;

namespace TestProject1
{
    internal class TestMethods
    {
        internal static uint StackFirstPrime(Stack<uint> stack)
        {

            foreach (uint num in stack) // con esto recorremos la pila
            {
                if (IsPrime(num))
                    return num; // si encuentra un primo lo retorna ahi mismo
            }
            return 0; // si despues de recorrer TODA la pila, no encuentra primos, retorna 0
        }

        internal static Stack<uint> RemoveFirstPrime(Stack<uint> stack)
        {
            Stack<uint> tempStack = new Stack<uint>(); // creamos un pila temporal 
            bool removed = false; // un bool para determinar si ya borramos un primo 

            while (stack.Count > 0) // mientras la pila no este vacia, extrae elementos usando Pop
            {
                uint num = stack.Pop();
                if (!removed && IsPrime(num))
                {
                    removed = true; // si el nmo es primo y no ha sido borrado lo descarta y marca removed verdadero
                    continue;
                }
                tempStack.Push(num); // y si no es primo, o ya borramos el primo lo almacenamos en tempStack
            }

            while (tempStack.Count > 0)
            {
                stack.Push(tempStack.Pop()); // restauramos el contenido de la pila original en el nuevo orden
            }
            return stack;
        }

        internal static Queue<uint> CreateQueueFromStack(Stack<uint> stack)
        {
            Queue<uint> queue = new Queue<uint>(); // creamos una cola vacía

            foreach (uint num in stack) // recorremos la pila y agregamos cada elemento a la cona con Enqueue
            {
                queue.Enqueue(num);
            }

            return queue; // retornamos la cola que creamos 
        }

        internal static List<uint> StackToList(Stack<uint> stack)
        {
            List<uint> resultList = new List<uint>();

           
            foreach (uint num in stack) // Recorremos la pila y agregamos los elementos a la lista
            {
                resultList.Add(num);
            }

            return resultList; // retornamos la nueva lista
        }

        internal static bool FoundElementAfterSorted(List<int> list, int value)
        {
            int n = list.Count; // guardamos el tamaño de nuestra lista

            for (int i = 0; i < n - 1; i++) // recorremos la lista hasta el´penultimo elemento
            {
                int minIndex = i; // suponemos que el elemnto actual es el menor 

                // buscar el menor elemento en la parte no ordenada
                for (int j = i + 1; j < n; j++)
                {
                    if (list[j] < list[minIndex]) // comaparamos valores
                    {
                        minIndex = j; // actualizamos el indice del menor
                    }
                }

                // intercambiar si encontramos un número menor
                if (minIndex != i)
                {
                    int temp = list[i]; // guardamos ese valor en una lista temporal
                    list[i] = list[minIndex]; // movwmos el menor valor a la posicion actual
                    list[minIndex] = temp; // restauramos el valor original en la nueva posicion
                }
            }
                return BuscarNum(list, value); // metodo que busca el numero en nuestra lista
        }
        private static bool BuscarNum(List<int> list, int target)
        {
            int left = 0, right = list.Count - 1; // define los limites de busqueda
            while (left <= right)
            {
                int mid = left + (right - left) / 2; // calcula la mitad, o sea el inidce medio
                if (list[mid] == target) // si el numero que buscamos esta de casualidad jsuto en la mitad, retorna true
                    return true;
                else if (list[mid] < target) // si es menor busca en la mitad derecha
                    left = mid + 1;
                else // si es mayor busca en la izquierda
                    right = mid - 1;
            }
            return false; // si no lo encuentra retorna false
        }

        // metodo que verifica si es primo
        private static bool IsPrime(uint num)
        {
            if (num < 2) return false; // menor que 2 no es primo
            for (uint i = 2; i * i <= num; i++) // verifica si el numero es divisible entre 2 o la raiz del numero
            {
                if (num % i == 0)
                    return false;
            }
            return true; // si no encuentra divisores, retorna true
        }
    }
}