using System;

namespace AIContinuous;

public static class Optimize
{
  public static double Newton(
    Func<double, double> function,
    double x0,
    double h = 1e-2,
    double tol = 1e-4,
    int maxIter = 10000)
  {
    Func<double, double> diffFunc = x => Diff.Differentiate5P(function, x, 2.0 * h);
    Func<double, double> diffDiffFunc = x => Diff.Differentiate5P(diffFunc, x, h);

    return Root.Newton(diffFunc, diffDiffFunc, x0, tol, maxIter);
  }

  public static double chutaAiMeuFih(Func<double, double> function, double x0, double chutes)
  {
    var x = x0;
    double res = Newton(function, x);
    double lastRes = res;

    for (int i = 0; i < chutes; i++)
    {
      res = Newton(function, x);
      // if(res < lastRes)
      //   x
      lastRes = res;
    }

    return 0.0;
  }

  public static double DescendingGradient(
    Func<double, double> function,
    double x0,
    double lr = 1e-2)
  {
    double xp = x0;

    while (true)
    {
      var diff = Diff.Differentiate(function, xp);
      xp -= lr * diff;
    }
  }

  public static double[] DescendingGradient(
    Func<double[], double> function,
    double[] x0,
    double lr = 1e-2,
    double tol = 1e-4)
  {
    var dim =  x0.Length;
    var xp = (double[])x0.Clone();
    var diff = Diff.Gradient(function, xp);
    double diffNorm;

    do
    {
      diffNorm = 0.0;
      diff = Diff.Gradient(function, xp);

      for (int i = 0; i < dim; i++)
      {
        xp[i] -= lr * diff[i];
        diffNorm += Math.Abs(diff[i]);
      }

      diffNorm /= dim;
    } while (diffNorm > tol * dim);

    return xp;
  }
}