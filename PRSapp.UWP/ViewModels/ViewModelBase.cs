using PRSapp.UWP.ViewModels.Commands;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRSapp.UWP.ViewModels
{
    public class ViewModelBase
    {
        public ChangeForeGroundColorCommand ChangeForeGroundColorCommand { get; set; }
        public DeleteDataSingleCommand DeleteDataSingleCommand { get; set; }
        public DeleteMultipleAsyncCommand DeleteMultipleAsyncCommand { get; set; }

        public ViewModelBase()
        {
            ChangeForeGroundColorCommand = new ChangeForeGroundColorCommand(this);
            DeleteDataSingleCommand = new DeleteDataSingleCommand(this);
            DeleteMultipleAsyncCommand = new DeleteMultipleAsyncCommand(this);
        }

        public void ChangeForeGroundColorMethod()
        {
            //for release
            Trace.WriteLine("Trace - ChangeForeGroundColorMethod");
            //for debug
            Debug.WriteLine("Debug - ChangeForeGroundColorMethod");
        }
        public void DeleteDataSingleMethod()
        {            
            Trace.WriteLine("Trace - DeleteDataSingleMethod");
            Debug.WriteLine("Debug - DeleteDataSingleMethod");
        }
        public void DeleteMultipleAsycnMethod()
        {
            Trace.WriteLine("Trace - DeleteMultipleAsycnCommand");
            Debug.WriteLine("Debug - DeleteTitlesAsycnCommand");
        }     
    } 
}
