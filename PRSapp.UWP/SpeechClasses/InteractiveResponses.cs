using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Code Set - Interactive

namespace PRSapp.UWP.SpeechClasses
{
    public class InteractiveResponses
    {
        public int ResponseRepStatus { get; set; }
        public int ResponseTitleId { get; set; }
        public string ResponseTitleName { get; set; }
        public string ResponsePlName { get; set; }
        public string ResponseTtsRaw { get; set; }
        public string ResponseFileUri { get; set; }
        public bool ResponseIsRandomized { get; set; }

        // *Note Each Method, is equilivant to a single ICommand.

        /// <summary>
        ///  Make Titles change based on Timer Repitition Status.
        /// </summary>
        /// <param name="responseRepStatus"></param>
        /// <param name="responseTitleId"></param>
        /// <param name="responseTitleName"></param>
        /// <param name="responsePlName"></param>
        /// <param name="responseTtsRaw"></param>
        /// <param name="responseFileUri"></param>
        public void ChangeTitle(int responseRepStatus, int responseTitleId = 0, 
            string responseTitleName = "Status", string responsePlName = "NA", 
            string responseTtsRaw = "Status Info", string responseFileUri = "NA")
        {
            
            //if (plName == "PL10P")
            //{
            //    PlName = plName;
            //    Debug.WriteLine("plName: " + repStatus.ToString() + "\n");

                Debug.WriteLine("repStatus: " + responseRepStatus.ToString() + "\n");              
                if (responseRepStatus != 0)
                {
                ResponseRepStatus = responseRepStatus;
                    switch (responseRepStatus)
                    {
                        case 1:
                            ResponseTitleName = "1, - Speed - Rehearsal to Readiness.";
                         
                            return;
                        case 2:
                            ResponseTitleName = "2- , Speed - Window Shopping and Obvious Personal Space IceBreakers.";
                            return;
                        case 3:
                        ResponseTitleName = "3- , Speed - As soon as see them \"Mix it up\", \"light and casual\".";
                            return;
                        case 4:
                        ResponseTitleName = "4- , Speed - In under 2 minutes, Take them Aside.";
                            return;
                        case 5:
                        ResponseTitleName = "5 - Speed - As soon as you all are aside, Begin \"the Hard Sell\", touch them after they touch you first.";
                            return;
                        case 6:
                        ResponseTitleName = "6- , Speed - \"Dirty Talk\".";
                            return;
                        case 7:
                        ResponseTitleName = "7- , Speed - \"Closing, Logistics, and Cock-Block Handling\".";
                            return;
                        case 8:
                        ResponseTitleName = "8- , Keep them hot on the way home.";
                            return;
                        case 9:
                        ResponseTitleName = "9- , Speed - Mental Prepare to break final ice by all getting naked as soon as close door.";
                            return;
                        case 10:
                        ResponseTitleName = "10- , Speed - Tell them you had fun as soon as done, so you don't seem needy incase you want upper hand to see them again.";
                            return;
                        default:
                            return;
                        //1 - Speed - Rehearsal to Readiness.
                        //2 - Speed - Window Shopping and Obvious Personal Space IceBreakers.
                        //3 - Speed - As soon as see them "Mix it up", "light and casual".
                        //4 - Speed - In under 2 minutes, Take them Aside.
                        //5 - Speed - As soon as you all are aside, Begin "the Hard Sell", touch them after they touch you first.
                        //6 - Speed - "Dirty Talk".
                        //7 - Speed - "Closing, Logistics, and Cock-Block Handling".
                        //8 - Keep them hot on way home.
                        //9 - Speed - Mental Prepare to break final ice by all getting naked as soon as close door.
                        //10 - Speed - Tell them you had fun as soon as done, so you don't seem needy incase you want upper hand to see them again.
                }
            }

                //Test Optional Arguments Default Values
                Debug.WriteLine("Test Optional Arguments Default Values\n");
                Debug.WriteLine(ResponseRepStatus.ToString() + ", " + ResponseTitleId.ToString() + ", " +
                                responseTitleName + ", " + responseTtsRaw + ", " +
                                responseFileUri + "\n");
            //}
            //else
            //{
            //    Debug.WriteLine("in else >> plName: " + plName + "\n");
            //}

        }


       

        // Show Hints, Mnemonic devices, or helpful reminders and sayings.


        #region VISUALIZATION
        //_______________________________________________________________
        //
        //                          Page
        //_______________________________________________________________
        //  RepeaterUC-1      |  InteractiveUC    |   RepeaterUC-2
        //   Questions        |     Hints         |     Answers
        //      or            |   Mnemonics       |        or
        // Rehearse Prompts   |  Helpful Sayings  |   Degree of Ready
        
        #endregion
    }
}
