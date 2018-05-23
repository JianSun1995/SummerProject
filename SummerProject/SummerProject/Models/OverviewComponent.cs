using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace SummerProject.Models
{
    public class OverviewComponent
    {
        private readonly string _machineStatusColor;

        public OverviewComponent()
        {
            _machineStatusColor =Brushes.White.ToString();
        }

        public string MachineStatusColor
        {
            get => _machineStatusColor;
            set => MachineStatusColor = value;
        }
    }
}