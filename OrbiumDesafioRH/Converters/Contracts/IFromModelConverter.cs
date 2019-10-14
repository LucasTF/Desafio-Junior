namespace OrbiumDesafioRH.Converters.Contracts
{
    public interface IFromModelConverter<TModel, TViewItem>
    {
        TViewItem ConvertFromModel(TModel model);
    }
}
