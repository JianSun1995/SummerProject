using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SummerProject.Models;

namespace SummerProject.ViewModels
{
    public class OverviewViewModel
    {
        public List<OverviewComponent> OverviewComponents { get; set; }

        public OverviewViewModel()
        {
            OverviewComponents = new List<OverviewComponent>()
            {
                new OverviewComponent(),
                new OverviewComponent()
            };
        }
    }
}