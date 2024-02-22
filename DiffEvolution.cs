using System;
using System.Collections.Generic;

namespace AIContinuous;

public unsafe class DiffEvolution
{
  protected Func<double[], double> Fitness { get; }
  protected int Dimension { get; }
  protected int NPop { get; set; }
  protected List<double[]> Individuals { get; set; }
  protected List<double[]> Bounds  { get; set; }
  protected int BestIndividual { get; set; }
  protected double FitnessBest { get; set; }

  public DiffEvolution(Func<double[], double> fitness, List<double[]> bounds, int nPop)
  {
    this.Dimension = bounds.Count;
    this.NPop = nPop;
    this.Individuals = new(nPop);
    this.Bounds = bounds;
  }
  private void GeneratPopulation()
  {
    for (int i = 0; i < this.NPop; i++)
    {
      int dimension = Dimension;
      Individuals[i] = new double[dimension];

      for (int j = 0; j < dimension; j++)
      {
        Individuals[i][j] = Utils.Rescale(
          Random.Shared.NextDouble(),
          Bounds[j][0],
          Bounds[j][1]
        );
      }
    }
  }

  private void FindBestIndividual()
  {
    var fitnessBest = FitnessBest;
    for (int i = 0; i < NPop; i++)
    {
      var fitnessCurr = Fitness(Individuals[i]);

      if(fitnessCurr < fitnessBest)
      {
        BestIndividual = i;
        fitnessBest = fitnessCurr;
      }
    }
    FitnessBest = fitnessBest;
  }

  public double[] Mutate(double[] individual)
  {
    var newIndividual = new double[Dimension];

    newIndividual = Individuals[BestIndividual];

    for (int i = 0; i < Dimension; i++)
    {
      newIndividual[i] -= Individuals[Random.Shared.Next(NPop)][i] - Individuals[Random.Shared.Next(NPop)][i];
    }

    return newIndividual;
  }


  public double[] Optimize()
  {
    GeneratPopulation();
    FindBestIndividual();

    return Individuals[BestIndividual];
  }
}