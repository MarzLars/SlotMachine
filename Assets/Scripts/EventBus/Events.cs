/*
EventBus scripts from adammyhre (git-amend)
https://youtu.be/4_DTAnigmaQ?si=BF7lhOKeQxVikpJO

GitHub project page: https://github.com/adammyhre/Unity-Event-Bus
*/
public interface IEvent { }

public struct TestEvent : IEvent { }

public struct PlayerEvent : IEvent {
    public int health;
    public int mana;
}