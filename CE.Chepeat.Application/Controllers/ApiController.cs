
using CE.Chepeat.Application.Presenters;
using CE.Chepeat.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CE.Chepeat.Application.Controllers
{
    public class ApiController: IApiController
    {
        private readonly IUnitRepository _unitRepository;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly IJwtService _jwtService;


        public ApiController(IUnitRepository unitRepository, IMapper mapper, IConfiguration configuration, IJwtService jwtService)
        {
            _unitRepository = unitRepository;
            _mapper = mapper;
            _configuration = configuration;
            _jwtService = jwtService;
        }

        public IUserPresenter UserPresenter => new UserPresenter(_unitRepository, _mapper);    //
        public IAuthPresenter AuthPresenter => new AuthPresenter(_unitRepository, _mapper, _jwtService);
    }
}
