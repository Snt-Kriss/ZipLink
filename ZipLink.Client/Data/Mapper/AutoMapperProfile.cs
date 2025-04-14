using AutoMapper;
using ZipLink.Client.Data.ViewModel;
using ZipLink.Data.Models;

namespace ZipLink.Client.Data.Mapper
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Url, GetUrlVM>().ReverseMap();
        }
    }
}
