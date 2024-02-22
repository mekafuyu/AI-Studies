using System;

namespace AIContinuous;

public static partial class Root
{
  public static double Bissection(
    Func<double, double> function,
    double a,
    double b,
    double tol = 1e-4,
    int maxiter = 1000)
  {
    double low = a;
    double high = b;

    double firstTryL = function(low);
    double firstTryH = function(high);

    if (Math.Abs(firstTryL - 0) < tol)
      return low;

    if (Math.Abs(firstTryH - 0) < tol)
      return high;

    double res = Math.Abs(firstTryH - 0) < Math.Abs(firstTryL - 0) ? firstTryH : firstTryL;
    double middle = Math.Abs(firstTryH - 0) < Math.Abs(firstTryL - 0) ? high : low;

    for (int i = 0; i < maxiter; i++)
    {
      middle = (high - low) / 2 + low;
      res = function(middle);
      // double middle = (high + low) / 2;

      if(Math.Abs(res - 0) < tol)
        return middle;

      if(res <= 0)
        low = middle;
      if(res > 0)
        high = middle;
    }

    return middle;
  }
}