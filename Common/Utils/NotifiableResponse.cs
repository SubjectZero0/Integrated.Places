namespace Common.Utils
{
    public record NotifiableResponse<Tvalue>(Tvalue Value) where Tvalue : class { };
}