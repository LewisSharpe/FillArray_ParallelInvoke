using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FillArray_PInvoke
{
    /* 
----------------------------------------------------------------------------------------------------------------
 * CustomStopwatch.CS - 
--------------------------------------------------------------------------------------------------------------------------
  Class creates a customised stopwatch which allows fetch start and end time.
  Class embodies functions to start, stop, reset and/or restart.
  The class inherits behaviour from Stopwatch class embedded in System.Diagonistics.
--------------------------------------------------------------------------------------------------------------------------
*/
    public class CustomStopwatch : Stopwatch
    {
        /* 
  ----------------------------------------------------------------------------------------------------------------
  * Fetch Start/End time   -
  --------------------------------------------------------------------------------------------------------------------------
   Get/Set constructors allow to record start and end time that can brought together to create timestamp.
  --------------------------------------------------------------------------------------------------------------------------
       */
        public DateTime? StartAt { get; private set; }
        public DateTime? EndAt { get; private set; }
        /* 
  ----------------------------------------------------------------------------------------------------------------
  * Start  -
  --------------------------------------------------------------------------------------------------------------------------
   Function starts stopwatch and sets the start time of the stopwatch to current time.
  --------------------------------------------------------------------------------------------------------------------------
       */
        public void Start()
        {
            StartAt = DateTime.Now;
            base.Start();
        }
        /* 
----------------------------------------------------------------------------------------------------------------
* Stop  -
--------------------------------------------------------------------------------------------------------------------------
Function stops stopwatch and sets the end time of the stopwatch to current time.
--------------------------------------------------------------------------------------------------------------------------
*/
        public void Stop()
        {
            EndAt = DateTime.Now;
            base.Stop();
        }
        /* 
----------------------------------------------------------------------------------------------------------------
* Reset  -
--------------------------------------------------------------------------------------------------------------------------
Function resets stopwatch and sets the start time and end time of the stopwatch to NULL.
--------------------------------------------------------------------------------------------------------------------------
*/
        public void Reset()
        {
            StartAt = null;
            EndAt = null;
            base.Reset();
        }
        /* 
----------------------------------------------------------------------------------------------------------------
* Restart  -
--------------------------------------------------------------------------------------------------------------------------
Function restarts stopwatch and sets the start time of the stopwatch to the current time
and end time of the stopwatch to NULL. 
--------------------------------------------------------------------------------------------------------------------------
*/
        public void Restart()
        {
            StartAt = DateTime.Now;
            EndAt = null;
            base.Restart();
        }
    }
}
