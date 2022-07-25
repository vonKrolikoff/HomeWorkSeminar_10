// Задача 73: Есть число N. Сколько групп M, можно получить при разбиении всех чисел на группы, 
// так чтобы в одной группе все числа в группе друг на друга не делились? 
// Найдите M при заданном N и получите одно из разбиений на группы N ≤ 10²⁰.
// Например, для N = 50, M получается 6
int n = Input("Введите число N: ");

int[] tempArray = MakeArray(n);
CreateRow(tempArray);

void CreateRow(int[] arrayCheck)
{
  int[] arrayTemp = new int[arrayCheck.Length];
  int m = 1;
  int count = 0;
  int tempNum1 = 0;
  int tempNum2 = 0;
  int switcher = 0;
  
  for (int i = 0; i < arrayCheck.Length; i++)
  {
    Array.Clear(arrayTemp);
    count = 0;
    if (arrayCheck[i] != 0)
    {
      arrayTemp[count] = arrayCheck[i];
      tempNum2 = arrayCheck[i];

      for (int j = i; j < arrayCheck.Length; j++)
      {
        if (arrayCheck[j] % tempNum2 != 0 || arrayCheck[j] / tempNum2 == 1)
        {
          switcher = 0;
          tempNum1 = arrayCheck[j];
          for (int k = 0; k < count; k++)
          {
            if (tempNum1 % arrayTemp[k] == 0) switcher++;
          }
          if (switcher == 0)
          {
            arrayTemp[count] = arrayCheck[j];
            count++;
            arrayCheck[j] = 0;
          }
        }
      }
      Console.WriteLine($"Группа {m++}: {PrintArray(arrayTemp)}");
    }
  }
}

int Input(string input)
{
  Console.Write(input);
  int output = Convert.ToInt32(Console.ReadLine());
  return output;
}

int[] MakeArray(int n)
{
  int[] temp = new int[n];
  for (int i = 0; i < temp.GetLength(0); i++)
  {
    temp[i] = i + 1;
  }
  return temp;
}

string PrintArray(int[] array)
{
  string result = string.Empty;
  for (int i = 0; i < array.Length; i++)
  {
    if (array[i] != 0) result += $"{array[i],1} ";
  }
  return result;
}
