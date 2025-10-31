/*
EventBus scripts from adammyhre (git-amend)
https://youtu.be/4_DTAnigmaQ?si=BF7lhOKeQxVikpJO

GitHub project page: https://github.com/adammyhre/Unity-Event-Bus
*/

namespace EventBus
{
    public interface IEvent { }

    public struct ColumnRollEvent : IEvent {
        public int ColumnIndex;
    }
    public struct RowRollEvent : IEvent {
        public int RowIndex;
    }
    public struct RollCompleteEvent : IEvent {
    }
    public struct WinEvent : IEvent {
        public int WinAmount;
    }
    public struct LoseEvent : IEvent {
    }
}