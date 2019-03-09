using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Code Set - Interactive

namespace PRSapp.UWP.SpeechClasses
{
    public class Interactive
    {
        public int RepStatus { get; set; }
        public int TitleId { get; set; }
        public string TitleName { get; set; }
        public string PlName { get; set; }
        public string TtsRaw { get; set; }
        public string FileUri { get; set; }
        public bool IsRandomized { get; set; }

        // *Note Each Method, is equilivant to a single ICommand.

        /// <summary>
        ///  Make Titles change based on Timer Repitition Status.
        /// </summary>
        /// <param name="repStatus"></param>
        /// <param name="titleId"></param>
        /// <param name="titleName"></param>
        /// <param name="plName"></param>
        /// <param name="ttsRaw"></param>
        /// <param name="fileUri"></param>
        public void ChangeTitle(int repStatus, int titleId = 0, string titleName = "Status", string plName = "NA", string ttsRaw = "Status Info", string fileUri = "NA")
        {
            
            //if (plName == "PL10P")
            //{
            //    PlName = plName;
            //    Debug.WriteLine("plName: " + repStatus.ToString() + "\n");

                Debug.WriteLine("repStatus: " + repStatus.ToString() + "\n");              
                if (repStatus != 0)
                {
                    RepStatus = repStatus;
                    switch (RepStatus)
                    {
                        case 1:
                            TitleName = "Say the Point-to-Point, SED-IceBreakers Cycle 1-10 , Begin with IB 1.";
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
                            return;
                        case 2:
                            TitleName = "Say IB 2";
                            return;
                        case 3:
                            TitleName = "Say IB 3";
                            return;
                        case 4:
                            TitleName = "Say IB 4";
                            return;
                        case 5:
                            TitleName = "Say IB 5";
                            return;
                        case 6:
                            TitleName = "Say IB 6";
                            return;
                        case 7:
                            TitleName = "Say IB 7";
                            return;
                        case 8:
                            TitleName = "Say IB 8";
                            return;
                        case 9:
                            TitleName = "Say IB 9";
                            return;
                        case 10:
                            TitleName = "Say IB 10";
                            return;
                        default:
                            return;
                    }
                }

                //Test Optional Arguments Default Values
                Debug.WriteLine("Test Optional Arguments Default Values\n");
                Debug.WriteLine(repStatus.ToString() + ", " + titleId.ToString() + ", " +
                                titleName + ", " + ttsRaw + ", " +
                                fileUri + "\n");
            //}
            //else
            //{
            //    Debug.WriteLine("in else >> plName: " + plName + "\n");
            //}

        }


        /// <summary>
        ///  Make Titles change Randomly based on Timer Repitition Status.
        /// </summary>
        /// <param name="repStatus"></param>
        /// <param name="titleId"></param>
        /// <param name="titleName"></param>
        /// <param name="ttsRaw"></param>
        /// <param name="fileUri"></param>
        /// <param name="isRandomized"></param>
        //public void ChangeTitle(int repStatus, int titleId, string titleName, string ttsRaw, string fileUri, bool isRandomized)
        //{
        //}

        // Show Hints, Mnemonic devices, or helpful reminders and sayings.


        #region VISUALIZATION
        //  RepeaterUC-1      |  InteractiveUC    |   RepeaterUC-2
        //   Questions        |     Hints         |     Answers
        //      or            |   Mnemonics       |        or
        // Rehearse Prompts   |  Helpful Sayings  |   Degree of Ready
        #endregion
    }
}
