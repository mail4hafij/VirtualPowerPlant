namespace Core.Business;

public interface ILoadBalancer
{
    void TryGreedyBalance(int requestedPower);
    void TryProportionalBalance(int requestedPower);
}
