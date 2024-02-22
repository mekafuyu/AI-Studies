using System;
using System.Runtime.CompilerServices;
using AIContinuous;

// double MyFunction(double x)
// {
//   return x * x;
// }
// double DerMyFunction(double x)
// {
//   return 2.0 * x;
// }
// double MyFunction2(double x)
// {
//   return (Math.Sqrt(Math.Abs(x)) - 5 ) * x + 10;
// }
// double DerMyFunction2(double x)
// {
//   return (1 / 2 * Math.Sqrt(Math.Abs(x))) * x + (Math.Sqrt(Math.Abs(x)) - 5);
// }
// double MyFunction3(double x)
// {
//   return (x - 1) * (x - 1) + Math.Sin(x * x * x);
// }
// double MyFunction4(double[] vs)
// {
//   return vs[0] * vs[0] + vs[1] * vs[1];
// }
// double MyFunction5(double[] vs)
// {
//   return Math.Pow(vs[0] + vs[1] * 2 - 7, 2) + Math.Pow(2 * vs[0] + vs[1] - 5, 2);
// }
double MyFunction6(double[] vs)
{
  int n = vs.Length - 1;
  double result = 0;
  for (int i = 0; i < n; i++)
  {
    var t1 = vs[i + 1] - (vs[i] * vs[i]);
    var t2 = 1 - vs[i];
    result += 100 * t1 * t1 + t2 * t2;
  }

  return result;
}

var sol = 0.0;
double[] sol2 = new double[]{};
DateTime start = new();

// start = DateTime.Now;
// sol = Root.Bissection(MyFunction, -10, 10);
// Console.WriteLine((DateTime.Now - start).TotalMilliseconds);
// Console.WriteLine(sol);

// start = DateTime.Now;
// sol = Root.FalsePosition(MyFunction, -10, 10);
// Console.WriteLine((DateTime.Now - start).TotalMilliseconds);
// Console.WriteLine(sol);

// start = DateTime.Now;
// sol = Root.Newton(MyFunction2, DerMyFunction2, 10.0);
// Console.WriteLine((DateTime.Now - start).TotalMilliseconds);
// Console.WriteLine(sol);

// start = DateTime.Now;
// sol = Root.Newton(MyFunction2, double (double x) => Diff.Differentiate5P(MyFunction2, x), 10.0);
// sol = Optimize.Newton(MyFunction3, -100000.0);
// Console.WriteLine((DateTime.Now - start).TotalMilliseconds);
// Console.WriteLine(sol);

// start = DateTime.Now;
// sol = Root.Newton(MyFunction2, double (double x) => Diff.Differentiate5P(MyFunction2, x), 10.0);
// sol2 = Optimize.DescendingGradient(MyFunction4, new double[] {10, 10});
// Console.WriteLine((DateTime.Now - start).TotalMilliseconds);
// Console.WriteLine($"{sol2[0]}, {sol2[1]}");

// start = DateTime.Now;
// sol = Root.Newton(MyFunction2, double (double x) => Diff.Differentiate5P(MyFunction2, x), 10.0);
// sol2 = Optimize.DescendingGradient(MyFunction5, new double[] {5, 30});
// Console.WriteLine((DateTime.Now - start).TotalMilliseconds);
// Console.WriteLine($"{sol2[0]}, {sol2[1]}");

start = DateTime.Now;
// sol = Root.Newton(MyFunction2, double (double x) => Diff.Differentiate5P(MyFunction2, x), 10.0);
sol2 = Optimize.DescendingGradient(MyFunction6, new double[] {10, 10}, 1e-10, 1e-12);
Console.WriteLine((DateTime.Now - start).TotalMilliseconds);
Console.WriteLine($"{sol2[0]}, {sol2[1]}");