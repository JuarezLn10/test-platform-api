using Microsoft.AspNetCore.Mvc.ApplicationModels;
using TestPlatform.API.Shared.Infrastructure.Interfaces.ASP.Configuration.Extensions;

namespace TestPlatform.API.Shared.Infrastructure.Interfaces.ASP.Configuration;

/// <summary>
/// This convention modifies the route templates of controllers and their actions to use kebab-case naming.
/// </summary>
public class KebabCaseRouteNamingConvention : IControllerModelConvention
{
    /// <summary>
    /// This method replaces the [controller] token in the route template with the kebab-case version of the controller name.
    /// </summary>
    private static AttributeRouteModel? ReplaceControllerTemplate(SelectorModel selector, string name)
    {
        return selector.AttributeRouteModel != null ? new AttributeRouteModel
        {
            Template = selector.AttributeRouteModel.Template?.Replace("[controller]", name.ToKebabCase())
        } : null;
    }
    
    /// <summary>
    /// This method applies the kebab-case naming convention to the controller and its actions.
    /// </summary>
    public void Apply(ControllerModel controller)
    {
        foreach (var selector in controller.Selectors)
        {
            selector.AttributeRouteModel = ReplaceControllerTemplate(selector, controller.ControllerName);
        }

        foreach (var selector in controller.Actions.SelectMany(a => a.Selectors))
        {
            selector.AttributeRouteModel = ReplaceControllerTemplate(selector, controller.ControllerName);
        }
    }
}