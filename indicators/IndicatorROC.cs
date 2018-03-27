﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyMachineConsole.indicators
{
    public class IndicatorROC: IIndicator
    {
        public string getName()
        {
            return "ROC";
        }



        public Operation GetOperation(double[] arrayPriceOpen, double[] arrayPriceClose, double[] arrayPriceLow, double[] arrayPriceHigh, double[] arrayVolume)
        {
            try
            {
                int outBegidx, outNbElement;
                double[] arrayresultTA = new double[arrayPriceClose.Length];
                arrayresultTA = new double[arrayPriceClose.Length];
                TicTacTec.TA.Library.Core.Roc(0, arrayPriceClose.Length - 1,   arrayPriceClose, 9, out outBegidx, out outNbElement, arrayresultTA);
                double value = arrayresultTA[outNbElement - 1];
                if (value > 0)
                    return Operation.sell;
                if (value < 0)
                    return Operation.buy;
                return Operation.nothing;
            }
            catch
            {
                return Operation.nothing;
            }
        }
    }
}
