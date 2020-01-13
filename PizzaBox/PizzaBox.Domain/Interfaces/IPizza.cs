using System;
using System.Collections.Generic;
using System.Text;
using PizzaBox;

namespace PizzaBox.Domain.Interfaces
{
    public interface IPizza
    {
       /// <summary>
       /// 
       /// </summary>
        public void SelectCrust();

        /// <summary>
        /// 
        /// </summary>
        public void SelectSize();

        /// <summary>
        /// 
        /// </summary>
        public void ComputeCost();

        /// <summary>
        /// 
        /// </summary>
        public void SelectToppingsW_Default();

        /// <summary>
        /// 
        /// </summary>
        public void LimitToppingNumber();
    }
}
