using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace NeuralNet
{
    public class Neuron
    {
        public List<double> Weight { get;}
        public NeuronType NeuronType { get; }
        public double Output { get; private set; }

        public Neuron(int inputCount, NeuronType type = NeuronType.Hidden)
        {
            NeuronType = type;
            Weight = new List<double>();
            for (int i = 0; i < inputCount; i++)
            {
                Weight.Add(1.0);
            }
        }

        public double FeedForward(List<double> signalsList)
        {
            #region Проверки

            if (signalsList.Count != Weight.Count)
            {
                throw new ArgumentOutOfRangeException("Количество сигналов не совпадает с количеством входов!");
            }

            #endregion


            double sum = 0.0;
            for (int i = 0; i < signalsList.Count; i++)
            {
                sum += signalsList[i] * Weight[i];
            }

            Output = Sigmoid(sum);

            return Output;
        }

        private double Sigmoid(double x)
        {
            var result = 1.0 / (1 + Math.Exp(-x));
            return result;
        }

        public override string ToString()
        {
            return Output.ToString();
        }
    }
}
