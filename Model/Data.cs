namespace SolveWebApp.Model
{
    public class Data
    {
        // Значения точек
        public double[] x { get; set; }
        // Значения функции
        public double[] y { get; set; }
        // Левая граница
        public double xn { get; set; }
        // Правая граница
        public double xk { get; set; }
        // Шаг
        public double xh { get; set; }
        // Значение для условия
        public double a { get; set; }

        static public double f1(double x) 
        {
            return Math.Round(Math.Pow(Math.Sin(Math.Pow(x, 3)), 2), 2);
        }
        static public double f2(double x)
        {
            return Math.Round(Math.Pow(6 * x - Math.Pow(x, 2) + 1,  1.0 / 5.0), 2);
        }
        static public double f3(double x)
        {
            return Math.Round(Math.Sin(x - Math.Pow(Math.E, -x)), 2);
        }
    }
}
