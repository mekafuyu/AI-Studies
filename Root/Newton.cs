using System;

namespace AIContinuous;

public static partial class Root
{
  public static double Newton(
    Func<double, double> function,
    Func<double, double> der,
    double x0,
    double tol = 1e-4,
    int maxIter = 10000)
  {
    double xp = x0;

    for (int i = 0; i < maxIter; i++)
    {
      var fxp = function(xp);

      xp -= fxp / der(xp);

      if(Math.Abs(fxp) < tol)
        break;
    }

    return xp;
  }
}