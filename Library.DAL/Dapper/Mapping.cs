using Dapper.FluentMap;

namespace Library.DAL.Dapper
{
    public static class Mapping
    {
        public static void InitializeMapping()
        {
            FluentMapper.Initialize(config =>
            {

            });
        }
    }
}