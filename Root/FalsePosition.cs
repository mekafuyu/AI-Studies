using System;

namespace AIContinuous;

public static partial class Root
{
  public static double FalsePosition(
    Func<double, double> function,
    double a,
    double b,
    double tol = 1e-4,
    int maxiter = 1000)
  {
    double low = a;
    double high = b;

    double lowy = function(a);
    double highy = function(b);

    double res = 0;
    double nextPoint = 0;

    for (int i = 0; i < maxiter; i++)
    {
      // nextPoint = (high - low) / 2 + low;

      // nextPoint = ((lowy - highy) / (low - high)) * (0 - low) + highy;

      // Y = ((lowy - highy) / (low - high)) * (X - low) + highy;
      // highy = ((lowy - highy) / (low - high)) * (X - low)
      // highy / ((lowy - highy) / (low - high)) = X - low
      // highy / ((lowy - highy) / (low - high)) + low = X

      nextPoint = highy / ((lowy - highy) / (low - high)) + low;


      res = function(nextPoint);

      if(Math.Abs(res - 0) < tol)
        break;

      if(res <= 0)
      {
        low = nextPoint;
        lowy = res;
      }
      if(res > 0)
      {
        high = nextPoint;
        highy = res;
      }
    }
    return nextPoint;
  }
}