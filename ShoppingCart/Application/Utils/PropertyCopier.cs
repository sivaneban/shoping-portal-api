

namespace Tiqri.CloudShoppingCart.Application.Utils
{
    public static class PropertyCopier<TSource, TTarget> where TSource : class where TTarget : class
    {
        public static void Copy(TSource source, TTarget target)
        {
            var sourceProperties = source.GetType().GetProperties();
            var targetProperties = target.GetType().GetProperties();

            foreach (var sourceProperty in sourceProperties)
            {
                foreach (var targetProperty in targetProperties)
                {
                    if (sourceProperty.Name != targetProperty.Name ||
                        sourceProperty.PropertyType != targetProperty.PropertyType) continue;
                    targetProperty.SetValue(target, sourceProperty.GetValue(source));
                    break;
                }
            }
        }
    }
}
