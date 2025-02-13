double a = 0.0, b = 0.0, result;
bool isRight = true;
try
{
    Console.Write("Введите вещественное число: ");
    a = Convert.ToDouble(Console.ReadLine());
    Console.Write("Введите второе вещественное число: ");
    b = Convert.ToDouble(Console.ReadLine());
}
catch (Exception)
{
    Console.WriteLine("Вы ввели не число!!!!");
}
if (isRight)
{
    result = a / b;
    Console.WriteLine(result);
}