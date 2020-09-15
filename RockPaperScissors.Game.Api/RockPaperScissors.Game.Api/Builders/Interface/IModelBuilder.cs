using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RockPaperScissors.Game.Api.Builders.Interface
{
    public interface IModelBuilder<TModel, TRequest>
    {
        TModel CreateFrom(TRequest fromRequest);
    }
}
