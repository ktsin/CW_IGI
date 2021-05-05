using AutoMapper;

namespace BLL.Converters
{
    public static class MapperConfig
    {
        private static MapperConfiguration _conf = null;

        public static MapperConfiguration Configuration
        {
            get
            {
                if (_conf == null)
                {
                    _conf = new();
                    return _conf;
                }
            };
        }
    }
    }
}