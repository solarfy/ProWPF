using System;

namespace ProWPF.PerFrameAnimations.ParticleEffect
{
    class TimeTracker
    {
        //上次执行的时间
        public DateTime LastTime { get; private set; }

        //时间增量（秒）
        public double DeltaSeconds { get; private set; }

        //定期执行的回调事件
        public EventHandler TimerFired = null;

        public TimeTracker()
        {
            LastTime = DateTime.Now;
        }

        public double Update()
        {
            DateTime currentTime = DateTime.Now;
            DeltaSeconds = (currentTime - LastTime).TotalSeconds;

            TimerFired?.Invoke(this, null);

            LastTime = currentTime;
            return DeltaSeconds;
        }
    }
}
