public abstract class BaseState<T>{
    public abstract void EnterState(T player);
    public abstract void UpdateState(T player);
    public abstract void FixedUpdateState(T player);
    public abstract void ExitState(T player);
}
