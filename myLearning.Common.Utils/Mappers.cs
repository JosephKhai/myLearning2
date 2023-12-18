namespace myLearning.Common.Utils
{
    public static class Mappers
    {
        public static TResult MapTo<TResult>(this object source)
            where TResult : class
        {
            return AutoMapper.Mapper.Map<TResult>(source);
        }
    }
}
