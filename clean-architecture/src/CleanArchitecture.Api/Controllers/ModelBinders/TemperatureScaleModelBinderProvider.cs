using CleanArchitecture.Api.Domain;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;

namespace CleanArchitecture.Api.Controllers.ModelBinders;

public class TemperatureScaleModelBinderProvider : IModelBinderProvider
{
    public IModelBinder? GetBinder(ModelBinderProviderContext context)
    {
        if (context.Metadata.ModelType == typeof(TemperatureScale))
        {
            return new BinderTypeModelBinder(typeof(TemperatureScaleModelBinder));
        }
        return null;
    }
}