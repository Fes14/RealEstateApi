namespace Api.Sevices
{
    public interface IRealStateMapper
    {
        TDest Map<TDest>(object src);
    }
}
