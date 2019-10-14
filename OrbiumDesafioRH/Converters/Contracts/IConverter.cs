namespace OrbiumDesafioRH.Converters.Contracts
{
    public interface IConverter<TModel, TViewItem> : IToModelConverter<TModel, TViewItem>, IFromModelConverter<TModel, TViewItem>
    {
    }
}
