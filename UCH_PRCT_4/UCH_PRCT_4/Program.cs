using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace UCH_PRCT_4
{
    class Program
    {
        static void Main()
        {


            // берем какие-то 3 числа u, v, w
            var u = new Complex(1, 2);
            var v = new Complex(3, 4);
            var w = new Complex(5, 6);

            // вычисляем функцию
            var f = F(u, v, w);

            // выводим на экран результат
            Console.WriteLine(f);

            // Ждем нажатия Enter
            Console.ReadLine();
        }

        // функция из задания, на вход три числа, на выход значение формулы
        static Complex F(Complex u, Complex v, Complex w)
        {
            return 2 * u + 3 * u * w / (2 + w - u) - 7;
        }
    }

    struct Complex
    {
        // Два неизменяемых поля (менять нельзя, можно создавать новые комплексные числа)
        public readonly double Re; // действиесльная часть комплексного числа
        public readonly double Im; // мнимая часть

        /* Конструктор структуры, чтобы можно было писать так:
           Complex c = new Complex(1, 2); // 1 + 2i
           или так:
           Complex c = new Complex(3);    // 3 + 0i
        */
        public Complex(double Re, double Im = 0)
        {
            this.Re = Re;
            this.Im = Im;
        }

        /* Метод создает строку для печати. 
           Чтобы можно было писать так:
           Complex c = new Complex(11.1, 22.2);
           Console.WriteLine(c); // (11,1; 22,2)
        */
        public override string ToString() => $"({Re}; {Im})";

        /* опрератор неявного (implicit) преобразования вещественного числа к комплексному
           чтобы можно было писать так:
           Complex a = 3; // вместо new Complex(3);
           или так:
           Complex b = 3 * a;  
        */
        public static implicit operator Complex(double Real) => new Complex(Real);

        /* операторы сложения, вычитания умножения и деления, на вход два комплексных числа,
           на выход третье. Формулы на википедии. Чтобы можно было писать так:
           Complex a = ... , b = ..., c;
           c = a * b;
           c = a + b;
           ... 
        */
        public static Complex operator +(Complex A, Complex B) => new Complex(A.Re + B.Re, A.Im + B.Im);
        public static Complex operator -(Complex A, Complex B) => new Complex(A.Re - B.Re, A.Im - B.Im);
        public static Complex operator *(Complex A, Complex B) => new Complex(
            A.Re * B.Re - A.Im * B.Im,
            A.Re * B.Im + A.Im * B.Re);
        public static Complex operator /(Complex A, Complex B) => new Complex(
            (A.Re * B.Re + A.Im * B.Im) / (B.Re * B.Re + B.Im * B.Im),
            (A.Im * B.Re - A.Re * B.Im) / (B.Re * B.Re + B.Im * B.Im));
    }

}
