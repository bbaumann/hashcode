using System.Diagnostics;

namespace hashcode.tools.timemanagement
{


/**
 * @author Manwe
 *
 * Time management class in order to measure elapsed time and avoid time outs
 * The Timer class uses the System.nanoTime() method to get the time. It is not executed in a separated thread, you must use the timeCheck method in order to verify the timeout has not been reached during the execution of your computation
 */
public class Timer {

    private Stopwatch stopwatch = new Stopwatch();
    private long timeout=0;

    /**
     * @return
     *  the number of nanoseconds between last time the timer has been started and now
     *  Will return System.nanoTime() if the timer has never been started
     */
    public long currentTimeTakenTicks() {
        return stopwatch.ElapsedTicks;
    }

    /**
     * Start the timer. 
     * If the timer is already started, will simply define the timeout as now + duration
     * A call to this method is mandatory if you want the timeCheck method to throws timeout exceptions
     * 
     * @param durationInMilliseconds
     * 		The duration in milliseconds from now until which the timeCheck method will throws Timeoutexceptions
     */
    public void startTimer(long durationInMilliseconds) {
        stopwatch.Reset();
        stopwatch.Start();        
        timeout = (long)durationInMilliseconds*1000000;
    }

    /**
     * Verify if the timeout has been reached. If yes, throws a TimeoutException
     * will not throw anything if the timer has never been started.
     * @throws TimeoutException
     */
    public void timeCheck() {
        if (stopwatch.ElapsedTicks > timeout) {
            throw new TimeoutException();
        }
    }
}

}