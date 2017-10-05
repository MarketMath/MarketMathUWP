using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketMathUWP
{
    /// <summary>
    /// Model of a geometric brownian motion. The stochastic process behind this model 
    /// satisfies the following stochastic differential equation: dSt = my*St*dt + sigma*St*dWt
    /// </summary>
    public class GeometricBrownianMotion : IRandomProcess
    {
        /// <summary>
        /// Represents my in the SDE.
        /// </summary>
        public double Drift { get; set; }

        /// <summary>
        /// Represents sigma in the SDE
        /// </summary>
        public double Vola { get; set; }

        private double CurrentValue { get; set; } = 1;

        Random rand = new Random();

        /// <summary>
        /// Creates a new geometric brownian motion and sets the start position of that motion to 
        /// the given startValue parameter.
        /// </summary>
        /// <param name="startValue">Starting position of the geometric brownian motion</param>
        public GeometricBrownianMotion(double startValue)
        {
            CurrentValue = startValue;
        }

        /// <summary>
        /// Returns the new value of the stochastic process after delta time has passed.
        /// </summary>
        /// <param name="deltaTime">time that has passed</param>
        /// <returns>New value of the stochastic process.</returns>
        public double GetValue(double deltaTime)
        {
            double steadyTerm = Drift * CurrentValue * deltaTime;
            double randomTerm = Vola * CurrentValue * rand.NormalDistributetRandPolarMethod(0, deltaTime);
            CurrentValue = steadyTerm + randomTerm;
            return CurrentValue;
        }
    }
}
