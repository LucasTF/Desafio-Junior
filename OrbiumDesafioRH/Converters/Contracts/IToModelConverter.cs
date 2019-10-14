namespace OrbiumDesafioRH.Converters.Contracts
{
    public interface IToModelConverter<TModel, TViewItem>
    {
        TModel ConvertToModel(TViewItem viewItem);
    }
}
