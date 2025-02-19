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
            list.Sort();// ordena la lista de menos a mayor
            return BuscarNum(list, value); // metodo que busca el numero en nuestra lista
        }
        private static bool BuscarNum(List<int> list, int target)
        {
            int left = 0, right = list.Count - 1;
            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                if (list[mid] == target)
                    return true;
                else if (list[mid] < target)
                    left = mid + 1;
                else
                    right = mid - 1;
            }
            return false;
        }

        // metodo que verifica si es primo
        private static bool IsPrime(uint num)
        {
            if (num < 2) return false;
            for (uint i = 2; i * i <= num; i++)
            {
                if (num % i == 0)
                    return false;
            }
            return true;
        }
    }
}