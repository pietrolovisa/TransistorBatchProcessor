using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TransisterBatch.EntityFramework.Extensions
{
    public static class PropertyBuilderExtensions
    {
        public static PropertyBuilder<T> IsReqiredWithMaxLength<T>(this PropertyBuilder<T> propertyBuilder, int maxLength)
        {
            return propertyBuilder
                    .IsRequired()
                    .HasMaxLength(maxLength);
        }

        public static PropertyBuilder<T> HasXmlColumnType<T>(this PropertyBuilder<T> propertyBuilder)
        {
            return propertyBuilder
                    .HasColumnType("xml");
        }

        public static PropertyBuilder<T> HasTextColumnType<T>(this PropertyBuilder<T> propertyBuilder)
        {
            return propertyBuilder
                    .HasColumnType("text");
        }
    }
}