public interface INasaClient<in Tin, out Tout>
{
    public Tout GetAsync(Tin input);
}
