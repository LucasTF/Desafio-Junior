using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrbiumDesafioRH.Converters.Contracts
{
    public interface IToModelConverter<TModel, TViewItem>
    {
        TModel ConvertToModel(TViewItem viewItem);
    }
}
