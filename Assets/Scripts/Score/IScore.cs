public interface IScore
{
    int Score { get; set; }
    void IncreaseScore(int value);
    void DiscountScore(int value);
}
