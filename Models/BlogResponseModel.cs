using netRestApi.Models;

namespace netRestApi.BlogResponseModel
{
    public class BlogResponseModel
    {
        public int pageNo { get; set; }
        public int pageSize { get; set; }
        public int pageCount { get; set; }
        public bool IsEndOfPage { get; set; }
        public List<BlogDataModel> Data { get; set; }
    }
} 