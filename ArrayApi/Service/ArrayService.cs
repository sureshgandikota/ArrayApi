
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArrayApi.Service
{
    public static class ArrayService<T> where T : new()
    {
        

        public static T[] Reverse(T[] inputList)
        {
            try
            {
                int size = inputList.Count<T>();
                for (int i = 0, j = size - 1; i < j; i++, j--)
                {
                    var temp = inputList[i];
                    inputList[i] = inputList[j];
                    inputList[j] = temp;
                }

                return inputList;
            }
            catch (Exception e)
            {
                throw new Exception("Something unexpected happened.");
            }
            
        }

        public static T[] DeletePart(int index,T[] inputList)
        {
            int size = inputList.Count<T>();
            if (index < 0 || index > size)
            {
                throw new IndexOutOfRangeException("Index value is out of range. please enter correct index value.");
            }

            T[] outputList = new T[size - 1];
            int i = 0;
            for (i = 0; i < index - 1; i++)
            {
                outputList[i] = inputList[i];
            }

            for (int j = index; j < size; j++)
            {
                outputList[i++] = inputList[j];
            }

            return outputList;
            
        }
    }
}
